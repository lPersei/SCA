using Entities.Heroes;
using UniRx;
using UnityEngine;
using Zenject;

namespace Entities.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public int Id { get; private set; }

        [Inject(Id = "Enemy")] private IEntitiesPresenter _presenter;
        [Inject(Id = "Hero")] private IEntityPresenter _heroPresenter;
        
        private Vector3 _heroPosition;

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
            
            _heroPresenter.Entity
                .Subscribe(x =>
                {
                    _heroPosition = x.Position;
                })
                .AddTo(this);
        }

        private void Update()
        {
            _presenter.Move(Id, Vector3.MoveTowards(transform.position, _heroPosition, 5 * Time.deltaTime));
            _presenter.Rotate(Id, transform.rotation * Quaternion.Euler(0, 0, 90 * Time.deltaTime));
        }
    }
}