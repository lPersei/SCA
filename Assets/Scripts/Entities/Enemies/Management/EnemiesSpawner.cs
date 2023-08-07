using System;
using Entities.Heroes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.Enemies
{
    public class EnemiesSpawner : MonoBehaviour, IEntitiesSpawnerPresenter
    {
        private GameObject _prefab;
        
        private IEntitiesManagementUsecase _entitiesManagementUsecase;
        
        public void Initialize(IEntitiesManagementUsecase entitiesManagementUsecase, GameObject prefab)
        {
            _prefab = prefab;
            _entitiesManagementUsecase = entitiesManagementUsecase;
        }

        public void Spawn()
        {
            var spawnPosition = new Vector3(Random.Range(0,20), 0, Random.Range(0,20));
            
            var enemyInstance = Instantiate(_prefab,spawnPosition, Quaternion.identity, transform);
            var id = enemyInstance.GetInstanceID();
            
            var enemy = new Enemy(id)
            {
                Hp = 1,
                Attack = 1,
                Position = spawnPosition,
                Rotation = Quaternion.identity
            };
            
            _entitiesManagementUsecase.CreateEntity(enemy);
        }
    }
}