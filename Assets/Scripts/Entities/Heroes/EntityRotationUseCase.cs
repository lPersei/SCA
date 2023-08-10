using UniRx;
using UnityEngine;

namespace Entities.Heroes
{
    public class EntityRotationUseCase : IEntityRotationUseCase
    {
        public IReadOnlyReactiveProperty<Entity> Entity => _hero;
        private readonly ReactiveProperty<Entity> _hero;

        public EntityRotationUseCase(ReactiveProperty<Entity> hero)
        {
            _hero = hero;
        }
        
        public void RotateEntity(Quaternion rotation)
        {
            var hero = _hero.Value;
            hero.Rotation = rotation;
            _hero.SetValueAndForceNotify(hero);
        }
    }
}