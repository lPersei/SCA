using Entities.Enemies;
using UnityEngine;

namespace Entities
{
    public class EnemiesTerminator : IEntitiesTerminator
    {
        private readonly IEntitiesManagementUsecase _managementUsecase;

        public EnemiesTerminator(IEntitiesManagementUsecase managementUsecase)
        {
            _managementUsecase = managementUsecase;
        }
        
        public void Terminate()
        {
            _managementUsecase.DeleteEntity(GameObject.FindObjectOfType<EnemyView>().gameObject.GetInstanceID());   
        }
    }
}