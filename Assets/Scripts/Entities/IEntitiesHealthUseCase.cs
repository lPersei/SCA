using UniRx;

namespace Entities
{
    public interface IEntitiesHealthUseCase
    {
        public IReadOnlyReactiveDictionary<int, ReactiveProperty<int>> Health { get; }

        public void IncreaseHealth(int id, int amount);
        public void DecreaseHealth(int id, int amount);
    }
}