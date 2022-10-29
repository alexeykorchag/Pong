using Mirror;
using Mirror.Discovery;
using UnityEngine;
using Zenject;


public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private NetworkManager networkManager;
    [SerializeField]
    private NetworkDiscovery networkDiscovery;
    [SerializeField]
    private UIController uiController;

    [SerializeField]
    private GameController gameController;

    public override void InstallBindings()
    {
        InstallNetwork();
        InstallManager();
        InstallUI();

        Container.BindInstance(gameController).AsSingle();
    }

    private void InstallNetwork()
    {
        Container.BindInstance(networkManager).AsSingle();
        Container.BindInstance(networkDiscovery).AsSingle();       
    }

    private void InstallManager()
    {
        Container.BindInterfacesAndSelfTo<ConnectionManager>().AsSingle();        
    }

    private void InstallUI()
    {
        Container.BindInstance(uiController).AsSingle();
    }
}
