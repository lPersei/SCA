using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesTransformUsecase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }
        
        public void MoveEntity(int id, Vector3 position);
        public void RotateEntity(int id, Quaternion rotation);
    }
}