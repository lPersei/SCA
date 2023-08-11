using UniRx;
using UnityEngine;

namespace Entities
{
    public interface IEntitiesPresenter
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Entity>> Entities { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Vector3>> Positions { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<Quaternion>> Rotations { get; }
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<int>> Health { get; }
        
        public void Move(int id, Vector3 position);
        public void Rotate(int id, Quaternion rotation);
        public void DealDamage(int id, int damage);
        public void Heal(int id, int damage);
    }
}