using UniRx;
using UnityEngine;

namespace Entities.Heroes
{
    public class HeroPresenter : IEntityPresenter
    {
        public IReadOnlyReactiveProperty<Entity> Entity { get; }
        private readonly IEntityMovementUseCase _movementUseCase;
        private readonly IEntityRotationUseCase _rotationUseCase;

        public HeroPresenter( IEntityMovementUseCase movementUseCase, IEntityRotationUseCase rotationUseCase)
        {
            _movementUseCase = movementUseCase;
            _rotationUseCase = rotationUseCase;
            
            Entity = _movementUseCase.Entity;
        }
        
        public void Move(Vector3 position)
        {
            _movementUseCase.MoveEntity(position);
        }

        public void Rotate(Quaternion rotation)
        {
            _rotationUseCase.RotateEntity(rotation);
        }
    }
}