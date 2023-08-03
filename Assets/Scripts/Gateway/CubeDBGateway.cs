using System.Collections.Generic;
using UnityEngine;

namespace SCA
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
                    Index = i,
                    Color = Color.white
                });
            }
        }
        
        public void SetColor(int index, Color newColor)
        {
            _cubes[index].Color = newColor;
        }

        public Color GetColor(int index)
        {
            return _cubes[index].Color;
        }
    }
}