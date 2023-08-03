using Zenject;

namespace SCA
{
    public class CubesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gateway = new CubeDBGateway();
            var usecase = new CubeUsecase(gateway);
            var presenter = gameObject.AddComponent<CubePresenter>();
            presenter.Initialize(usecase);
            
            Container
                .Bind<ICubeDBGateway>()
                .FromInstance(gateway);
            
            Container
                .Bind<ICubeUsecase>()
                .FromInstance(usecase);
            
            Container
                .Bind<ICubePresenter>()
                .FromInstance(presenter);
        }
    }
}