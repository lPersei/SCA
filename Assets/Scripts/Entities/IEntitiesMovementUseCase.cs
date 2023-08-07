using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesMovementUseCase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }
        
        public void MoveEntity(int id, Vector3 position);
    }
}