using UnityEngine;

namespace SCA
{
    public interface ICubeDBGateway
    {
        void SetColor(int index, Color newColor);
        Color GetColor(int index);
    }
}