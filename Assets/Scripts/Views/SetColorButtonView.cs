using Presenters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class SetColorButtonView : MonoBehaviour
    {
        public int id;
        
        [Inject] private ICubePresenter _presenter;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(() => {
                _presenter.ChangeColor(id, Random.ColorHSV());
            });
        }
    }
}