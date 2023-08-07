using Entities.Enemies;
using Entities.Heroes.Management;
using UnityEngine;
using Zenject;

namespace Entities.Heroes
{
    public class HeroesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;
        public override void InstallBindings()
        {
            var db = new HeroesDb();
        
            var managementUseCase = new EntitiesManagementUsecase(db);
            var movementUseCase = new EntitiesMovementUseCase(db);
            var rotationUseCase = new EntitiesRotationUseCase(db);
        
            var presenter = new HeroesPresenter(movementUseCase, rotationUseCase);
            var spawner = gameObject.AddComponent<HeroesSpawner>();
            spawner.Initialize(managementUseCase, _prefab);
            //var terminator = new HeroesTerminator(managementUseCase);
        
            Container
                .Bind<IEntityPresenter>()
                .WithId("Hero")
                .FromInstance(presenter)
                .AsCached();
            
            // Container
            //     .Bind<IEntitiesSpawnerPresenter>()
            //     .FromInstance(spawner)
            //     .AsCached();
            //
            // Container
            //     .Bind<IEntitiesTerminator>()
            //     .FromInstance(terminator)
            //     .AsCached();
        }
    }
}