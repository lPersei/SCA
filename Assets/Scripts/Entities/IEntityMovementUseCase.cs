using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntityMovementUseCase
    {
        public IReadOnlyReactiveProperty<Entity> Entity { get; }
        
        public void MoveEntity(Vector3 position);
    }
}