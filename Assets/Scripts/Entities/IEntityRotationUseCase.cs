using UniRx;
using UnityEngine;

namespace Entities.Heroes
{
    public interface IEntityRotationUseCase
    {
        public IReadOnlyReactiveProperty<Entity> Entity { get; }
        
        public void RotateEntity(Quaternion rotation);
    }
}