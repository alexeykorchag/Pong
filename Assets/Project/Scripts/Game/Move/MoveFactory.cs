using Mirror;


public class MoveFactory
{

    public static IMove CreateMove(NetworkBehaviour behaviour, PlayerSettings _playerSettings)
    {
        var move = Create(behaviour);
        move.Create(behaviour.gameObject, _playerSettings.Move);
        return move;
    }

    private static IMove Create(NetworkBehaviour behaviour)
    {
        if (behaviour.isLocalPlayer)
            return new LocalMove();
        else
            return new ServerMove();
    }
}

