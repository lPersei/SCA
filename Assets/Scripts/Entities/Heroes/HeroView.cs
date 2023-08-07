using UniRx;
using UnityEngine;
using Zenject;

namespace Entities.Heroes
{
    public class HeroView : MonoBehaviour
    {
        [Inject(Id = "Hero")] private IEntityPresenter _presenter;
        
        public int Id { get; private set; }

        private void Awake()
        {
            Id = gameObject.GetInstanceID();
        }
        
        private void Start()
        {
            _presenter.Entities.ObserveRemove()
                .Subscribe(x =>
                {
                    if (x.Key == Id)
                    {
                        Destroy(gameObject);
                    }
                })
                .AddTo(this);

            _presenter.Entities.ObserveReplace()
                .Subscribe(x =>
                {
                    if (x.Key == Id)
                    {
                        transform.SetPositionAndRotation(x.NewValue.Position, x.NewValue.Rotation);
                    }
                })
                .AddTo(this);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _presenter.Move(Id, transform.position + transform.forward * 5 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _presenter.Move(Id, transform.position - transform.forward * 5 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _presenter.Move( Id, transform.position - transform.right * 5 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _presenter.Move(Id, transform.position + transform.right * 5 * Time.deltaTime);
            }
        }
    }
}