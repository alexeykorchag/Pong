using Mirror;
using UnityEngine;

public class NetworkManagerPong : NetworkManager
{
    [SerializeField]
    private Transform leftRacketSpawn;

    [SerializeField]
    private Transform rightRacketSpawn;

    private GameObject _ball;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        TryToSpawnPlayer(conn);
        TryToSpawnBall(conn);
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

        NetworkServer.AddPlayerForConnection(conn, player);
        return true;
    }

    private bool TryToSpawnBall(NetworkConnectionToClient conn)
    {
        if (numPlayers != 2) return false;

        _ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));

        NetworkServer.Spawn(_ball);
        return true;

    }



}

