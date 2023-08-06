using UniRx;
using UnityEngine;
using Zenject;

namespace Entities.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public int Id { get; private set; }

        [Inject] private IEntityPresenter _presenter;

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
                });
            
            
        }

        private void Update()
        {
            _presenter.Move(Id, transform.position + transform.up * Time.deltaTime);
            _presenter.Rotate(Id, transform.rotation * Quaternion.Euler(0, 0, 90 * Time.deltaTime));
        }
    }
}