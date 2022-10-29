using Mirror;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [SerializeField]
    private BallSettings settings;

    [SerializeField]
    private Rigidbody2D rigidbody2d;

    public override void OnStartServer()
    {
        base.OnStartServer();

        rigidbody2d.simulated = true;

        SetDefaultPosition();
        SetRandomVelocity();
    }

    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.TryGetComponent<Bounds>(out var bounds))
        {
            bounds.AddPoint(-col.transform.position.x);
            SetDefaultPosition();
            SetRandomVelocity();
        }

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

    private static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
