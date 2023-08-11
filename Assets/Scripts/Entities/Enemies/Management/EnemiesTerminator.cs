using UnityEngine;

namespace Entities.Enemies.Management
{
    public class EnemiesTerminator : IEntitiesTerminator
    {
        private readonly IEntitiesManagementUseCase managementUseCase;

        public EnemiesTerminator(IEntitiesManagementUseCase managementUseCase)
        {
            this.managementUseCase = managementUseCase;
        }
        
        public void Terminate(int id)
        {
            managementUseCase.DeleteEntity(id);   
        }
    }
}