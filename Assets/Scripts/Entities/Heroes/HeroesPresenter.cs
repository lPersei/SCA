using UniRx;
using UnityEngine;

namespace Entities.Heroes
{
    public class HeroesPresenter : IEntityPresenter
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }
        private readonly IEntitiesMovementUseCase _movementUseCase;
        private readonly IEntitiesRotationUseCase _rotationUseCase;

        public HeroesPresenter( IEntitiesMovementUseCase movementUseCase, IEntitiesRotationUseCase rotationUseCase)
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