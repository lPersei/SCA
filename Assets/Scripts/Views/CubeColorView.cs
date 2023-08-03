using UniRx;
using UnityEngine;
using Zenject;

namespace SCA
{
    public class CubeColorView : MonoBehaviour
    {
        public int index;
        
        [Inject] private ICubePresenter _presenter;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            var rxProperty = _presenter.Cubes[index];

            rxProperty.Subscribe(cube => UpdateColor(cube.Color)).AddTo(this);
        }
        
        private void UpdateColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}