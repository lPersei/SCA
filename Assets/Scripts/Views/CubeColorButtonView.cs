using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SCA
{
    public class CubeColorButtonView : MonoBehaviour
    {
        public int index;
        
        [Inject] private ICubePresenter _presenter;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(() => {
                _presenter.ChangeColor(index, Random.ColorHSV());
            });
        }
    }
}