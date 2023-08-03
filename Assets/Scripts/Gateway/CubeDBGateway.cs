using System.Collections.Generic;
using Enities;
using UnityEngine;

namespace Gateway
{
    public class CubeDBGateway : ICubeDBGateway
    {
        private readonly List<Cube> _cubes;

        public CubeDBGateway()
        {
            _cubes = new List<Cube>();
            
            for(var i = 0; i < 4; i++)
            {
                _cubes.Add(new Cube
                {
                    Id = i,
                    Color = Color.white
                });
            }
        }
        
        public void SetColor(int id, Color newColor)
        {
            _cubes[id].Color = newColor;
        }

        public Color GetColor(int id)
        {
            return _cubes[id].Color;
        }
    }
}