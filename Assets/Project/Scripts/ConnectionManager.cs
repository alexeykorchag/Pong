using Mirror;
using Mirror.Discovery;
using System;
using System.Collections.Generic;
using Zenject;

public class ConnectionManager
{

    private NetworkManager _networkManager;
    private NetworkDiscovery _networkDiscovery;

    public event Action<Uri> ServerDiscovered;

    private Dictionary<long, ServerResponse> _discoveredServers = new Dictionary<long, ServerResponse>();

    public ConnectionManager(NetworkManager networkManager, NetworkDiscovery networkDiscovery)
    {
        _networkManager = networkManager;
        _networkDiscovery = networkDiscovery;

        _networkDiscovery.OnServerFound.AddListener(OnDiscoveredServer);
    }   

    public void FindServer()
    {
        _discoveredServers.Clear();
        _networkDiscovery.StartDiscovery();
    }

    private void OnDiscoveredServer(ServerResponse info)
    {
        ServerDiscovered?.Invoke(info.uri);

        _discoveredServers[info.serverId] = info;
    }

    public void StartHost()
    {
        _discoveredServers.Clear();

        _networkManager.StartHost();
        _networkDiscovery.AdvertiseServer();
    }

    public void Connect(string networkAddress)
    {
        _networkDiscovery.StopDiscovery();

        _networkManager.networkAddress = networkAddress;
        _networkManager.StartClient();
    }

}
