using UniRx;
using UnityEngine;

namespace Entities.Heroes
{
    public class HeroesDb : IEntityDbGateway
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities => _heroes;
        private readonly ReactiveDictionary<int, Entity> _heroes = new();
        
        public void AddEntity(Entity newEntity)
        {
            _heroes.Add(newEntity.Id, newEntity);
        }

        public void RemoveEntity(int id)
        {
            _heroes.Remove(id);
        }

        public void UpdateEntity(int id, Entity updatedEntity)
        {
            _heroes[id] = updatedEntity;
        }

        public Entity GetEntity(int id)
        {
            return _heroes[id];
        }

        public void UpdateEntityPosition(int id, Vector3 position)
        {
            var hero = _heroes[id];
            hero.Position = position;
            _heroes[id] = hero;
        }

        public void UpdateEntityRotation(int id, Quaternion rotation)
        {
            var hero = _heroes[id];
            hero.Rotation = rotation;
            _heroes[id] = hero;
        }
    }
}