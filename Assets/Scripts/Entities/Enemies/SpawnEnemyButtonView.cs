using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Entities.Enemies
{
    public class SpawnEnemyButtonView : MonoBehaviour
    {
        [Inject(Id = "Enemy")]
        private IEntitiesSpawnerPresenter _spawner;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => {
                
                for (int i = 0; i < 10; i++)
                {
                    _spawner.Spawn();
                }
            });
        }
    }
}