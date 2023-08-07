using UnityEngine;

namespace Entities.Heroes.Management
{
    public class HeroesSpawner : MonoBehaviour, IEntitiesSpawnerPresenter
    {
        private IEntitiesManagementUsecase _entitiesManagementUsecase;
        private GameObject _prefab;
        
        public void Initialize(IEntitiesManagementUsecase entitiesManagementUsecase, GameObject prefab)
        {
            _entitiesManagementUsecase = entitiesManagementUsecase;
            _prefab = prefab;
        }
        
        private void Start()
        {
            var hero = FindObjectOfType<HeroView>();
            _entitiesManagementUsecase.CreateEntity(new Hero(hero.gameObject.GetInstanceID())
            {
                Hp = 10,
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
                Hp = 10,
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
            };
            
            _entitiesManagementUsecase.CreateEntity(newHero);
        }
    }
}