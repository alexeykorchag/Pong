using Mirror;
using UnityEngine;
using Zenject;

public class NetworkManagerPong : NetworkManager
{
    [Inject]
    private DiContainer container;
    [Inject]
    private UIController uiController;
    [Inject]
    private GameController gameController;



    [SerializeField]
    private Transform leftRacketSpawn;

    [SerializeField]
    private Transform rightRacketSpawn;

    private GameObject _ball;

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        uiController.OpenWindow<GameWindow>();
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        TryToSpawnPlayer(conn);
        TryToSpawnBall(conn);

        if (numPlayers == 2) gameController.StartNewGame();
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // destroy ball
        if (_ball != null)
            NetworkServer.Destroy(_ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }

    private bool TryToSpawnPlayer(NetworkConnectionToClient conn)
    {
        if (numPlayers >= 2) return false;

        // add player at correct spawn position
        var start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        var player = Instantiate(playerPrefab, start.position, start.rotation);
        container.Inject(player.GetComponent<Player>());

        NetworkServer.AddPlayerForConnection(conn, player);
        return true;
    }

    private bool TryToSpawnBall(NetworkConnectionToClient conn)
    {
        if (numPlayers != 2) return false;

        _ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
        container.Inject(_ball.GetComponent<Ball>());

        NetworkServer.Spawn(_ball);
        return true;

    }



}

