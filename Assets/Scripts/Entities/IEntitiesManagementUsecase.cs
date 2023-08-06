using UniRx;

namespace Entities
{
    public interface IEntitiesManagementUsecase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }
        
        public void CreateEntity(Entity newEntity);
        public void DeleteEntity(int id);
    }
}