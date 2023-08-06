using UnityEngine;
using Zenject;

namespace Entities.Enemies
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;
        public override void InstallBindings()
        {
            var db = new EnemiesDb();
        
            var managementUsecase = new EntitiesManagementUsecase(db);
            var transformUsecase = new EnemiesTransformUsecase(db);
        
            var presenter = new EnemiesPresenter(transformUsecase);
            var spawner = gameObject.AddComponent<EnemiesSpawner>();
            spawner.Initialize(managementUsecase, _prefab);
            var terminator = new EnemiesTerminator(managementUsecase);
            
            Container
                .Bind<IEntityDbGateway>()
                .FromInstance(db)
                .AsCached();

            Container
                .Bind<IEntitiesManagementUsecase>()
                .FromInstance(managementUsecase)
                .AsCached();

            Container
                .Bind<IEntitiesTransformUsecase>()
                .FromInstance(transformUsecase)
                .AsCached();
        
            Container
                .Bind<IEntityPresenter>()
                .FromInstance(presenter)
                .AsCached();
            
            Container
                .Bind<IEntitiesSpawnerPresenter>()
                .FromInstance(spawner)
                .AsCached();
            
            Container
                .Bind<IEntitiesTerminator>()
                .FromInstance(terminator)
                .AsCached();
        }
    }
}