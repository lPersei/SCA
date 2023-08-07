using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesRotationUseCase
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }
        
        public void RotateEntity(int id, Quaternion rotation);
    }
}