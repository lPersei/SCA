using UniRx;
using UnityEngine;

namespace Entities.Heroes
{
    public class EntityMovementUseCase : IEntityMovementUseCase
    {
        public IReadOnlyReactiveProperty<Entity> Entity => _hero;
        private readonly ReactiveProperty<Entity> _hero;

        public EntityMovementUseCase(ReactiveProperty<Entity> hero)
        {
            _hero = hero;
        }
        
        public void MoveEntity(Vector3 position)
        {
            var hero = _hero.Value;
            hero.Position = position;
            _hero.SetValueAndForceNotify(hero);
        }
    }
}