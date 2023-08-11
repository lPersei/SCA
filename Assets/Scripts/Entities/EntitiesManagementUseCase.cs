using UniRx;

namespace Entities
{
    public class EntitiesManagementUseCase : IEntitiesManagementUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Entity>> Entities { get; }

        private readonly IEntitiesDbGateway _dbGateway;
        
        public EntitiesManagementUseCase(IEntitiesDbGateway dbGateway)
        {
            _dbGateway = dbGateway;
            Entities = _dbGateway.Entities;
        }
        
        public void CreateEntity(Entity newEntity)
        {
            _dbGateway.AddEntity(newEntity);
        }

        public void DeleteEntity(int id)
        {
            _dbGateway.RemoveEntity(id);
        }
    }
}