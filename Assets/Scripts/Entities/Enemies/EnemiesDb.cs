using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesDb : IEntityDbGateway
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities => _enemies;
        private readonly ReactiveDictionary<int, Entity> _enemies = new ();

        public void AddEntity(Entity newEntity)
        {
            _enemies.Add(newEntity.Id, newEntity);
        }

        public void RemoveEntity(int id)
        {
            _enemies.Remove(id);
        }

        public void UpdateEntity(int id, Entity updatedEntity)
        {
            _enemies[id] = updatedEntity;
        }

        public Entity GetEntity(int id)
        {
            return _enemies[id];
        }
        
        public void UpdateEntityPosition(int id, Vector3 position)
        {
            var enemy = _enemies[id];
            enemy.Position = position;
            _enemies[id] = enemy;
        }
        
        public void UpdateEntityRotation(int id, Quaternion rotation)
        {
            var enemy = _enemies[id];
            enemy.Rotation = rotation;
            _enemies[id] = enemy;
        }
    }
}