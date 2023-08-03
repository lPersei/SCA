using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SCA
{
    public class CubePresenter : MonoBehaviour, ICubePresenter
    {
        private ICubeUsecase _usecase;

        public List<ReactiveProperty<Cube>> Cubes { get; } = new()
        {
            new ReactiveProperty<Cube>(), 
            new ReactiveProperty<Cube>(), 
            new ReactiveProperty<Cube>(),
            new ReactiveProperty<Cube>()
        };

        public void Initialize(ICubeUsecase usecase)
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
            Cubes[cube.Index].Value = cube;
        }

        public void ChangeColor(int index, Color color)
        {
            _usecase.ChangeColor(index, color);
        }
    }
}