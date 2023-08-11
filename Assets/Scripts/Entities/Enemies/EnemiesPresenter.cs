using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesPresenter : IEntitiesPresenter
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Entity>> Entities { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Vector3>> Positions { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Quaternion>> Rotations { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<int>> Health { get; }

        private readonly IEntitiesHealthUseCase _healthUseCase;
        private readonly IEntitiesManagementUseCase _managementUseCase;
        private readonly IEntitiesMovementUseCase _movementUseCase;
        private readonly IEntitiesRotationUseCase _rotationUseCase;

        public EnemiesPresenter(IEntitiesMovementUseCase movementUseCase, IEntitiesRotationUseCase rotationUseCase, IEntitiesManagementUseCase managementUseCase, IEntitiesHealthUseCase healthUseCase)
        {
            _movementUseCase = movementUseCase;
            _rotationUseCase = rotationUseCase;
            _managementUseCase = managementUseCase;
            _healthUseCase = healthUseCase;

            Entities = _managementUseCase.Entities;
            Positions = _movementUseCase.Positions;
            Rotations = _rotationUseCase.Rotations;
            Health = _healthUseCase.Health;
        }

        public void Move(int id, Vector3 position)
        {
            _movementUseCase.MoveEntity(id, position);
        }

        public void Rotate(int id, Quaternion rotation)
        {
            _rotationUseCase.RotateEntity(id, rotation);
        }

        public void DealDamage(int id, int damage)
        {
            _healthUseCase.DecreaseHealth(id, damage);

            if (Health[id].Value == 0)
            {
                _managementUseCase.DeleteEntity(id);
            }
        }

        public void Heal(int id, int damage)
        {
            
        }
    }
}