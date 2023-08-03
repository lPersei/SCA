using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SCA
{
    public class CubeUsecase : ICubeUsecase
    {
        private readonly ICubeDBGateway _gateway;

        public List<ReactiveProperty<Cube>> Cubes { get; } = new();

        public CubeUsecase(ICubeDBGateway gateway)
        {
            _gateway = gateway;

            for (int i = 0; i < 4; i++)
            {
                Cubes.Add(new ReactiveProperty<Cube>(new Cube
                {
                    Index = i,
                    Color = _gateway.GetColor(i)
                }));
            }
        }
        
        public void ChangeColor(int index, Color color)
        {
            _gateway.SetColor(index, color);
            
            Cubes[index].Value = new Cube
            {
                Index = index,
                Color = color
            };
        }
    }
}