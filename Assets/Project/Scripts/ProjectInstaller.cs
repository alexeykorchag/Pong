using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Settings/Installers/Project")]
public class ProjectInstaller : MonoInstaller<ProjectInstaller>
{
    [SerializeField] PlayerSettings playerSettings;

    public override void InstallBindings()
    {
        InstallSettings();
    }

    void InstallSettings()
    {
        Container.BindInstance(playerSettings).AsSingle();
    }
}
