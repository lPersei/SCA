using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntityPresenter
    {
        public IReadOnlyReactiveProperty<Entity> Entity { get; }
        
        public void Move(Vector3 position);
        public void Rotate(Quaternion rotation);
    }
}