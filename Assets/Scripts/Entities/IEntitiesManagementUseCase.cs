using UniRx;

namespace Entities
{
    public interface IEntitiesManagementUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Entity>> Entities { get; }
        
        public void CreateEntity(Entity newEntity);
        public void DeleteEntity(int id);
    }
}