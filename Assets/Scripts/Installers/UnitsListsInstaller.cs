using System.Collections.Generic;
using Unit_Scripts;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UnitsListsInstaller : MonoInstaller
    {
        [SerializeField] private UnitsLists _unitsLists = new UnitsLists();
        public override void InstallBindings()
        {
            Container.Bind<UnitsLists>().FromInstance(_unitsLists).AsSingle();
        }
    }
}