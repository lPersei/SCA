using UniRx;
using UnityEngine;

namespace Entities.Transforms
{
    public class EntitiesRotationUseCase : IEntitiesRotationUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Quaternion>> Rotations { get; }

        private readonly IEntitiesDbGateway _entitiesDb;
        
        public EntitiesRotationUseCase(IEntitiesDbGateway entitiesDb)
        {
            _entitiesDb = entitiesDb;
            Rotations = _entitiesDb.EntitiesRotations;
        }

        public void RotateEntity(int id, Quaternion rotation)
        {
            _entitiesDb.UpdateEntityRotation(id, rotation);
        }
    }
}