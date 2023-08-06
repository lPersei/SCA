using UniRx;

namespace Entities
{
    public interface IEntityDbGateway
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; } 
        public void AddEntity(Entity newEntity);
        public void RemoveEntity(int id);
        public void UpdateEntity(Entity updatedEntity);
        public Entity GetEntity(int id);
    }
}