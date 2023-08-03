using System.Collections.Generic;
using Enities;
using UniRx;
using UnityEngine;
using Usecases;

namespace Presenters
{
    public class CubePresenter : MonoBehaviour, ICubePresenter
    {
        private IColorUsecase _usecase;

        public List<ReactiveProperty<Cube>> Cubes { get; } = new()
        {
            new ReactiveProperty<Cube>(), 
            new ReactiveProperty<Cube>(), 
            new ReactiveProperty<Cube>(),
            new ReactiveProperty<Cube>()
        };

        public void Initialize(IColorUsecase usecase)
        {
            _usecase = usecase;

            foreach (var property in _usecase.Cubes)
            {
                property.Subscribe(UpdateCube).AddTo(this);

                UpdateCube(property.Value);
            }
        }

        void UpdateCube(Cube cube)
        {
            Cubes[cube.Id].Value = cube;
        }

        public void ChangeColor(int id, Color color)
        {
            _usecase.ChangeColor(id, color);
        }
    }
}