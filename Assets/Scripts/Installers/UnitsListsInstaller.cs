using Unit_Scripts;
using Zenject;

namespace Installers
{
    public class UnitsListsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UnitsLists>().FromNew().AsSingle();
        }
    }
}