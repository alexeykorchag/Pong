using Mirror;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : NetworkBehaviour
{
    [SerializeField]
    private PlayerSettings _playerSettings;

    private IMove _move;

    private void Start()
    {
        _move = MoveFactory.CreateMove(this, _playerSettings);
        _move.Enable();
    }

    //private void OnEnable()
    //{
    //    _move.Enable();
    //}

    //private void OnDisable()
    //{
    //    _move.Disable();
    //}

    private void FixedUpdate()
    {
        _move.Update(Time.fixedDeltaTime);
    }

    private void OnDestroy()
    {
        _move.Disable();
        _move.Dispose();
    }

}