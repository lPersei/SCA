using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Entities.Enemies
{
    public class SpawnEnemyButtonView : MonoBehaviour
    {
        [Inject]
        private IEntitiesSpawnerPresenter _spawner;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => {
                _spawner.Spawn();
            });
        }
    }
}