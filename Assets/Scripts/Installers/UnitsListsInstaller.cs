using Unit_Scripts;
using UnityEngine;
using Zenject;

public class UnitsListsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UnitsLists>().FromNew().AsSingle();
    }
}