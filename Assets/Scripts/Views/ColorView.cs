using Presenters;
using UniRx;
using UnityEngine;
using Zenject;

namespace Views
{
    public class ColorView : MonoBehaviour
    {
        public int id;
        
        [Inject] private ICubePresenter _presenter;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            var rxProperty = _presenter.Cubes[id];

            rxProperty.Subscribe(cube => UpdateColor(cube.Color)).AddTo(this);
        }
        
        private void UpdateColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}