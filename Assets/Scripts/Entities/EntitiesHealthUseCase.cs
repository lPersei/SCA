using UniRx;

namespace Entities
{
    public class EntitiesHealthUseCase : IEntitiesHealthUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<int>> Health { get; }
        private readonly IEntitiesDbGateway _entitiesDb;

        public EntitiesHealthUseCase(IEntitiesDbGateway entitiesDb)
        {
            _entitiesDb = entitiesDb;
            Health = _entitiesDb.Health;
        }

        public void IncreaseHealth(int id, int amount)
        {
            var entity = _entitiesDb.GetEntity(id);
            var health = entity.Health;
            var maxHealth = entity.MaxHealth;
            
            health += amount;

            if (health > maxHealth)
            {
                health = maxHealth;
            }

            _entitiesDb.UpdateEntityHealth(id, health);
        }

        public void DecreaseHealth(int id, int amount)
        {
            var entity = _entitiesDb.GetEntity(id);
            var health = entity.Health;
            
            health -= amount;

            if (health < 0)
            {
                health = 0;
            }

            _entitiesDb.UpdateEntityHealth(id, health);
        }
    }
}