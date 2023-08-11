using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesRotationUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Quaternion>> Rotations { get; }
        
        public void RotateEntity(int id, Quaternion rotation);
    }
}