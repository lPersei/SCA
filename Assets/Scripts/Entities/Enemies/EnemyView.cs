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
        private Rigidbody _rigidbody;

        private Vector3 _heroPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
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

            _presenter.Positions[Id]
                .Subscribe(x =>
                {
                    _rigidbody.velocity = x;
                })
                .AddTo(this);
            
            _presenter.Rotations[Id]
                .Subscribe(x =>
                {
                    transform.rotation = x;
                })
                .AddTo(this);
            
            _heroPresenter.Entity
                .Subscribe(x => { _heroPosition = x.Position; })
                .AddTo(this);
        }

        private void FixedUpdate()
        {
            _presenter.Move(Id, (_heroPosition - transform.position) * (5 * Time.fixedDeltaTime));
            _presenter.Rotate(Id, transform.rotation * Quaternion.Euler(0, 0, 90 * Time.fixedDeltaTime));
        }
    }
}