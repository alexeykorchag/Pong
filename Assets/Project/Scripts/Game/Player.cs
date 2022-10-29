using Mirror;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : NetworkBehaviour
{
    [Inject]
    private GameController gameController;

    [SerializeField]
    private PlayerSettings _playerSettings;

    private IMove _move;


    public override void OnStartClient()
    {
        base.OnStartClient();


    }

    public override void OnStopClient()
    {
        base.OnStopClient();


    }





    [Client]
    private void Start()
    {
        _move = MoveFactory.CreateMove(this, _playerSettings);
        _move.Enable();
    }

    [Client]
    private void FixedUpdate()
    {
        _move.Update(Time.fixedDeltaTime);
    }

    [Client]
    private void OnDestroy()
    {
        _move.Disable();
        _move.Dispose();
    }

}