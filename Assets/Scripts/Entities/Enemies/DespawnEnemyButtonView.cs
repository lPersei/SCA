using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Entities.Enemies
{
    public class DespawnEnemyButtonView : MonoBehaviour
    {
        [Inject(Id = "Enemy")] private IEntitiesTerminator _terminator;

        private Button _button;
        
        private void Start()
        {
            _button = GetComponent<Button>();

            _button.onClick.AddListener(() => _terminator.Terminate(FindObjectOfType<EnemyView>().gameObject.GetInstanceID()));
        }
    }
}