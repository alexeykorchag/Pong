using Mirror;
using UnityEngine;
using Zenject;

public class Ball : NetworkBehaviour
{
    [Inject]
    private GameController gameController;

    [SerializeField]
    private BallSettings settings;

    [SerializeField]
    private Rigidbody2D rigidbody2d;

    public override void OnStartServer()
    {
        base.OnStartServer();

        rigidbody2d.simulated = true;

        gameController.GameStarted += OnGameStarted;
        gameController.ResetPosition += OnGameStarted;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
       
        gameController.GameStarted -= OnGameStarted;
        gameController.ResetPosition -= OnGameStarted;
    }


    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.TryGetComponent<Bounds>(out var bounds))
        {
            bounds.AddPoint(-col.transform.position.x);
        }

    }

    private void OnGameStarted()
    {
        SetDefaultPosition();
        SetRandomVelocity();
    }
   

    private void SetDefaultPosition()
    {
        rigidbody2d.position = settings.Position.DefaultPosition;
    }

    private void SetRandomVelocity()
    {
        rigidbody2d.velocity = GetRandomDirection() * settings.Move.Speed;
    }

    private Vector2 GetRandomDirection()
    {
        var angle = Random.Range(-settings.Position.MaxStartAngle, settings.Position.MaxStartAngle);
        var sign = Mathf.Sign(Random.Range(-1, 1));
        var direction = (sign * Vector2.right).Rotate(angle);
        return direction;
    }

}
