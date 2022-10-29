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
        rigidbody2d.velocity = Vector2.right * settings.Move.Speed;
    }

    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.GetComponent<Player>())
        {
            var y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            var x = col.relativeVelocity.x > 0 ? 1 : -1;
            var dir = new Vector2(x, y).normalized;
            rigidbody2d.velocity = dir * settings.Move.Speed;
        }

        if (col.transform.TryGetComponent<Bounds>(out var bounds))
        {
            bounds.AddPoint(-col.transform.position.x);
        }

    }

    private static float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
