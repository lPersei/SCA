using UnityEngine;

namespace Entities.Heroes.Management
{
    public class HeroesSpawner : MonoBehaviour, IEntitiesSpawnerPresenter
    {
        private IEntitiesManagementUseCase entitiesManagementUseCase;
        private GameObject _prefab;
        
        public void Initialize(IEntitiesManagementUseCase entitiesManagementUseCase, GameObject prefab)
        {
            this.entitiesManagementUseCase = entitiesManagementUseCase;
            _prefab = prefab;
        }
        
        private void Start()
        {
            var hero = FindObjectOfType<HeroView>();
            entitiesManagementUseCase.CreateEntity(new Hero(hero.gameObject.GetInstanceID())
            {
                Health = 10,
                Position = hero.transform.position,
                Rotation = hero.transform.rotation
            });
        }
        
        public void Spawn()
        {
            var newHeroInstance = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
            var id = newHeroInstance.GetInstanceID();
            var newHero = new Hero(id)
            {
                Health = 10,
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
            };
            
            entitiesManagementUseCase.CreateEntity(newHero);
        }
    }
}