using UnityEngine;

namespace Entities.Heroes
{
    public class HeroesTerminator : IEntitiesTerminator
    {
        private readonly IEntitiesManagementUsecase _managementUsecase;

        public HeroesTerminator(IEntitiesManagementUsecase managementUsecase)
        {
            _managementUsecase = managementUsecase;
        }
        
        public void Terminate()
        {
            _managementUsecase.DeleteEntity(GameObject.FindObjectOfType<HeroView>().gameObject.GetInstanceID());   
        }
    }
}