using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntityDbGateway
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; } 
        public void AddEntity(Entity newEntity);
        public void RemoveEntity(int id);
        public void UpdateEntity(int id, Entity updatedEntity);
        public Entity GetEntity(int id);
        public void UpdateEntityPosition(int id, Vector3 position);
        public void UpdateEntityRotation(int id, Quaternion rotation);
    }
}