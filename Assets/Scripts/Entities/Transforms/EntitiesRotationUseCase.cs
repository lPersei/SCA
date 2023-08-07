using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EntitiesRotationUseCase : IEntitiesRotationUseCase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }

        private readonly IEntityDbGateway _entityDb;
        
        public EntitiesRotationUseCase(IEntityDbGateway entityDb)
        {
            _entityDb = entityDb;
            Entities = _entityDb.Entities;
        }

        public void RotateEntity(int id, Quaternion rotation)
        {
            _entityDb.UpdateEntityRotation(id, rotation);
        }
    }
}