using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMove : IMove
{
    private static readonly Vector2 asix = Vector2.up;

    private Controls _controls;
    private InputAction _move;

    private GameObject _root;
    private PlayerSettings.MoveSettings _settings;
    private Rigidbody2D _rigidbody;


    public void Create(GameObject root, PlayerSettings.MoveSettings settings)
    {
        _root = root;
        _settings = settings;

        _controls = new Controls();
        _move = _controls.Game.Move;

        _rigidbody = _root.GetComponent<Rigidbody2D>();
    }

    public void Enable()
    {
        _move.Enable();
    }

    public void Disable()
    {
        _move.Disable();
    }

    public void Update(float deltaTime)
    {
        var input = _move.ReadValue<float>();
        var delta = input * deltaTime * _settings.Speed;
        _rigidbody.velocity = asix * delta;
    }

    public void Dispose()
    {
        _controls.Dispose();
    }
}