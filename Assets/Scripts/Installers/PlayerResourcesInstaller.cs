using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerResourcesInstaller : MonoInstaller
    {
        [SerializeField] private PlayerResources _playerResources;
        public override void InstallBindings()
        {
            _playerResources.PlayerResourcesUI = FindObjectOfType<PlayerResourcesUI>();
            Container.Bind<PlayerResources>().FromInstance(_playerResources).AsSingle();
        }
    }
}
