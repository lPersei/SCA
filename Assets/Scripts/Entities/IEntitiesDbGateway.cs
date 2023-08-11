using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesDbGateway
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Entity>> Entities { get; } 
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<int>> Health { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Vector3>> EntitiesPositions { get; } 
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Quaternion>> EntitiesRotations { get; } 
        public void AddEntity(Entity newEntity);
        public void RemoveEntity(int id);
        public Entity GetEntity(int id);
        public void UpdateEntityPosition(int id, Vector3 position);
        public void UpdateEntityRotation(int id, Quaternion rotation);
        public void UpdateEntityHealth(int id, int health);
    }
}