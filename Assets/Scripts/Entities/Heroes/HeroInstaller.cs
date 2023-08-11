using Entities.Enemies;
using Entities.Heroes.Management;
using UniRx;
using UnityEngine;
using Zenject;

namespace Entities.Heroes
{
    public class HeroInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;

        private ReactiveProperty<Entity> _hero;

        public override void InstallBindings()
        {
            _hero = new ReactiveProperty<Entity>(new Hero(0)
            {
                Health = 20,
                Position = Vector3.zero,
                Rotation = Quaternion.identity
            });

            var movementUseCase = new EntityMovementUseCase(_hero);
            var rotationUseCase = new EntityRotationUseCase(_hero);

            var presenter = new HeroPresenter(movementUseCase, rotationUseCase);
            // var spawner = gameObject.AddComponent<HeroesSpawner>();
            // spawner.Initialize(managementUseCase, _prefab);
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