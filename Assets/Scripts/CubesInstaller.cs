using Gateway;
using Presenters;
using Usecases;
using Zenject;

public class CubesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var gateway = new CubeDBGateway();
        var usecase = new ColorUsecase(gateway);
        var presenter = gameObject.AddComponent<CubePresenter>();
        presenter.Initialize(usecase);
            
        Container
            .Bind<ICubeDBGateway>()
            .FromInstance(gateway);
            
        Container
            .Bind<IColorUsecase>()
            .FromInstance(usecase);
            
        Container
            .Bind<ICubePresenter>()
            .FromInstance(presenter);
    }
}