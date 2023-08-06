using UniRx;

namespace Entities
{
    public class EntitiesManagementUsecase : IEntitiesManagementUsecase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }

        private readonly IEntityDbGateway _dbGateway;
        
        public EntitiesManagementUsecase(IEntityDbGateway dbGateway)
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