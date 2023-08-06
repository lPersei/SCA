using UniRx;

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

        public void UpdateEntity(Entity updatedEntity)
        {
            _enemies[updatedEntity.Id] = updatedEntity;
        }

        public Entity GetEntity(int id)
        {
            return _enemies[id];
        }
    }
}