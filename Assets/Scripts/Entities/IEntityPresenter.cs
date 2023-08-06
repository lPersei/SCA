using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntityPresenter
    {
        public IReadOnlyReactiveDictionary<int, Entity> Entities { get; }
        
        public void Move(int id, Vector3 position);
        public void Rotate(int id, Quaternion rotation);
    }
}