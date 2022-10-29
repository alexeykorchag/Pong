using Mirror;
using Zenject;

public class Bounds : NetworkBehaviour
{
    [Inject]
    private GameController gameController;


    [Server]
    public void AddPoint(float direction)
    {
        if (direction < 0)
            gameController.AddPointToLeft();
        else
            gameController.AddPointToRight();
    }


}

