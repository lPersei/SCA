﻿using System;
using Entities.Enemies;
using UniRx;
using UnityEngine;
using Zenject;

namespace Entities.Heroes
{
    public class HeroView : MonoBehaviour
    {
        [Inject(Id = "Hero")] private IEntityPresenter _presenter;
        [Inject(Id = "Enemy")] private IEntitiesTerminator _enemyTerminator;
        
        public int Id { get; private set; }

        private void Awake()
        {
            Id = gameObject.GetInstanceID();
        }

        private void Start()
        {
            _presenter.Entity
                .Subscribe(x => { transform.SetPositionAndRotation(x.Position, x.Rotation); })
                .AddTo(this);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _presenter.Move(transform.position + transform.forward * 5 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                _presenter.Move(transform.position - transform.forward * 5 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _presenter.Move(transform.position - transform.right * 5 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _presenter.Move(transform.position + transform.right * 5 * Time.deltaTime);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent<EnemyView>(out _))
            {
                _enemyTerminator.Terminate(other.gameObject.GetInstanceID());
            }
        }
    }
}