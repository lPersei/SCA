using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EntitiesMovementUseCase : IEntitiesMovementUseCase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }

        private readonly IEntityDbGateway _entityDb;
        
        public EntitiesMovementUseCase(IEntityDbGateway entityDb)
        {
            _entityDb = entityDb;
            Entities = _entityDb.Entities;
        }
        
        public void MoveEntity(int id, Vector3 position)
        {
            _entityDb.UpdateEntityPosition(id, position);
        }
    }
}