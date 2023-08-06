using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesTransformUsecase : IEntitiesTransformUsecase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }

        private readonly IEntityDbGateway _entityDb;
        
        public EnemiesTransformUsecase(IEntityDbGateway entityDb)
        {
            _entityDb = entityDb;
            Entities = _entityDb.Entities;
        }
        
        public void MoveEntity(int id, Vector3 position)
        {
            var enemy = _entityDb.GetEntity(id);
            enemy.Position = position;
            
            _entityDb.UpdateEntity(enemy);
        }

        public void RotateEntity(int id, Quaternion rotation)
        {
            var enemy = _entityDb.GetEntity(id);
            enemy.Rotation = rotation;
            
            _entityDb.UpdateEntity(enemy);
        }
    }
}