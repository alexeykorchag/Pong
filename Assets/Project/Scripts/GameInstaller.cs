using UnityEngine;
using Zenject;


public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallFactories();
    }

    void InstallFactories()
    {
        Container.BindInterfacesAndSelfTo<MoveFactory>().AsSingle();
    }
}
