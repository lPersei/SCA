using UniRx;
using UnityEngine;

namespace Entities.Transforms
{
    public class EntitiesMovementUseCase : IEntitiesMovementUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Vector3>> Positions { get; }

        private readonly IEntitiesDbGateway _entitiesDb;

        public EntitiesMovementUseCase(IEntitiesDbGateway entitiesDb)
        {
            _entitiesDb = entitiesDb;
            Positions = _entitiesDb.EntitiesPositions;
        }

        public void MoveEntity(int id, Vector3 position)
        {
            _entitiesDb.UpdateEntityPosition(id, position);
        }
    }
}