using UniRx;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesPresenter : IEntityPresenter
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }

        private IEntitiesTransformUsecase _transformUsecase;

        public EnemiesPresenter(IEntitiesTransformUsecase transformUsecase)
        {
            _transformUsecase = transformUsecase;
            
            Entities = _transformUsecase.Entities;
        }
        
        public void Move(int id, Vector3 position)
        {
            _transformUsecase.MoveEntity(id, position);
        }

        public void Rotate(int id, Quaternion rotation)
        {
            _transformUsecase.RotateEntity(id, rotation);
        }
    }
}