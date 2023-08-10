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
        
            var managementUseCase = new EntitiesManagementUsecase(db);
            var movementUseCase = new EntitiesMovementUseCase(db);
            var rotationUseCase = new EntitiesRotationUseCase(db);
        
            var presenter = new EnemiesPresenter(movementUseCase, rotationUseCase);
            var spawner = gameObject.AddComponent<EnemiesSpawner>();
            spawner.Initialize(managementUseCase, _prefab);
            var terminator = new EnemiesTerminator(managementUseCase);
        
            Container
                .Bind<IEntitiesPresenter>()
                .WithId("Enemy")
                .FromInstance(presenter)
                .AsCached();
            
            Container
                .Bind<IEntitiesSpawnerPresenter>()
                .WithId("Enemy")
                .FromInstance(spawner)
                .AsCached();
            
            Container
                .Bind<IEntitiesTerminator>()
                .WithId("Enemy")
                .FromInstance(terminator)
                .AsCached();
        }
    }
}