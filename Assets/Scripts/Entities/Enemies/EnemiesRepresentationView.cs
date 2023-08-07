using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace Entities.Enemies
{
    public class EnemiesRepresentationView : MonoBehaviour
    {
        [Inject(Id = "Enemy")] private IEntityPresenter _presenter;

        [SerializeField] private Transform _grid;
        [SerializeField] private GameObject _uiPrefab;

        private List<GameObject> _uiInstances = new();
        
        private void Start()
        {
            _presenter.Entities.ObserveAdd()
                .Subscribe(_ =>
                {
                    var uiEnemyInstance = Instantiate(_uiPrefab, _grid);
                    _uiInstances.Add(uiEnemyInstance);
                });
            
            _presenter.Entities.ObserveRemove()
                .Subscribe(x =>
                {
                    Destroy(_uiInstances[0].gameObject);
                    _uiInstances.RemoveAt(0);
                });
        }
    }
}