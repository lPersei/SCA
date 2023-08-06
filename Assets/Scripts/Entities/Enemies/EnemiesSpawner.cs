using UnityEngine;

namespace Entities.Enemies
{
    public class EnemiesSpawner : MonoBehaviour, IEntitiesSpawnerPresenter
    {
        private GameObject _prefab;
        
        private Vector3 _spawnPosition = Vector3.zero;
        private IEntitiesManagementUsecase _entitiesManagementUsecase;
        
        public void Initialize(IEntitiesManagementUsecase entitiesManagementUsecase, GameObject prefab)
        {
            _prefab = prefab;
            _entitiesManagementUsecase = entitiesManagementUsecase;
        }

        public void Spawn()
        {
            var enemyInstance = Instantiate(_prefab,_spawnPosition, Quaternion.identity, transform);
            var id = enemyInstance.GetInstanceID();
            
            var enemy = new Enemy(id)
            {
                Hp = 1,
                Attack = 1,
                Position = _spawnPosition,
                Rotation = Quaternion.identity
            };
            
            _entitiesManagementUsecase.CreateEntity(enemy);
            
            _spawnPosition += Vector3.right * 2;
        }
    }
}