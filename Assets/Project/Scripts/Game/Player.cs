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

    private LocalPlayerMove _move;


    public override void OnStartServer()
    {
        base.OnStartServer();

        gameController.ResetPosition += SetDefaultPosition;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();

        gameController.ResetPosition -= SetDefaultPosition;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();     

        _move = new LocalPlayerMove();

        _move.Create(this.gameObject, _playerSettings.Move);
        _move.Enable();
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        gameController.ResetPosition -= SetDefaultPosition;

        _move.Disable();
        _move.Dispose();
    }

    [Client]
    private void FixedUpdate()
    {
        if (_move != null)
            _move.Update(Time.fixedDeltaTime);
    }

    [ClientRpc]
    private void SetDefaultPosition()
    {
        if (_move != null)
            _move.SetDefaultPosition();
    }

}