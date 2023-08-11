using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesDb : IEntitiesDbGateway
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Entity>> Entities => _enemies;
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<int>> Health => _health;
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Vector3>> EntitiesPositions => _entitiesPositions;
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Quaternion>> EntitiesRotations => _entitiesRotations;

        private readonly ReactiveDictionary<int, ReactiveProperty<Entity>> _enemies = new();
        private readonly ReactiveDictionary<int, ReactiveProperty<int>> _health = new();
        private readonly ReactiveDictionary<int, ReactiveProperty<Vector3>> _entitiesPositions = new();
        private readonly ReactiveDictionary<int, ReactiveProperty<Quaternion>> _entitiesRotations = new();

        public void AddEntity(Entity newEntity)
        {
            _enemies.Add(newEntity.Id, new ReactiveProperty<Entity>(newEntity));
            _health.Add(newEntity.Id, new ReactiveProperty<int>(newEntity.Health));
            _entitiesPositions.Add(newEntity.Id, new ReactiveProperty<Vector3>(newEntity.Position));
            _entitiesRotations.Add(newEntity.Id, new ReactiveProperty<Quaternion>(newEntity.Rotation));
        }

        public void RemoveEntity(int id)
        {
            _enemies.Remove(id);
            _health.Remove(id);
            _entitiesPositions.Remove(id);
            _entitiesRotations.Remove(id);
        }

        public Entity GetEntity(int id)
        {
            return _enemies[id].Value;
        }

        public void UpdateEntityPosition(int id, Vector3 position)
        {
            var enemy = _enemies[id].Value;
            enemy.Position = position;
            _enemies[id].Value = enemy;

            _entitiesPositions[id].Value = position;
        }

        public void UpdateEntityRotation(int id, Quaternion rotation)
        {
            var enemy = _enemies[id].Value;
            enemy.Rotation = rotation;
            _enemies[id].Value = enemy;

            _entitiesRotations[id].Value = rotation;
        }

        public void UpdateEntityHealth(int id, int health)
        {
            var enemy = _enemies[id].Value;
            enemy.Health = health;
            _enemies[id].Value = enemy;

            _health[id].Value = health;
        }
    }
}