using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesPresenter : IEntitiesPresenter
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }

        private readonly IEntitiesMovementUseCase _movementUseCase;
        private readonly IEntitiesRotationUseCase _rotationUseCase;

        public EnemiesPresenter(IEntitiesMovementUseCase movementUseCase, IEntitiesRotationUseCase rotationUseCase)
        {
            _movementUseCase = movementUseCase;
            _rotationUseCase = rotationUseCase;
            
            Entities = _movementUseCase.Entities;
        }
        
        public void Move(int id, Vector3 position)
        {
            _movementUseCase.MoveEntity(id, position);
        }

        public void Rotate(int id, Quaternion rotation)
        {
            _rotationUseCase.RotateEntity(id, rotation);
        }
    }
}