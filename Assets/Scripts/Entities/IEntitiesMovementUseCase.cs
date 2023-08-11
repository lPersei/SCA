using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesMovementUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Vector3>> Positions { get; }
        
        public void MoveEntity(int id, Vector3 position);
    }
}