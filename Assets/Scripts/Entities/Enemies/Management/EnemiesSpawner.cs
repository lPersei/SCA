using Entities.Heroes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.Enemies.Management
{
    public class EnemiesSpawner : MonoBehaviour, IEntitiesSpawnerPresenter
    {
        private GameObject _prefab;
        
        private IEntitiesManagementUseCase _managementUseCase;
        
        public void Initialize(IEntitiesManagementUseCase entitiesManagementUseCase, GameObject prefab)
        {
            _prefab = prefab;
            _managementUseCase = entitiesManagementUseCase;
        }

        public void Spawn()
        {
            var spawnPosition = FindObjectOfType<HeroView>().transform.position + new Vector3(Random.Range(-20,20), 0, Random.Range(-20,20));
            
            var enemyInstance = Instantiate(_prefab,spawnPosition, Quaternion.identity, transform);
            var id = enemyInstance.GetInstanceID();
            
            var enemy = new Enemy(id)
            {
                Health = 1,
                Attack = 1,
                Position = spawnPosition,
                Rotation = Quaternion.identity
            };
            
            _managementUseCase.CreateEntity(enemy);
        }
    }
}