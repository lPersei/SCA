using System.Collections.Generic;
using Enities;
using Gateway;
using UniRx;
using UnityEngine;

namespace Usecases
{
    public class ColorUsecase : IColorUsecase
    {
        private readonly ICubeDBGateway _gateway;

        public List<ReactiveProperty<Cube>> Cubes { get; } = new();

        public ColorUsecase(ICubeDBGateway gateway)
        {
            _gateway = gateway;

            for (int i = 0; i < 4; i++)
            {
                Cubes.Add(new ReactiveProperty<Cube>(new Cube
                {
                    Id = i,
                    Color = _gateway.GetColor(i)
                }));
            }
        }
        
        public void ChangeColor(int id, Color color)
        {
            _gateway.SetColor(id, color);
            
            Cubes[id].Value = new Cube
            {
                Id = id,
                Color = color
            };
        }
    }
}