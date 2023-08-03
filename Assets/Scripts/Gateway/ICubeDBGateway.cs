using UnityEngine;

namespace Gateway
{
    public interface ICubeDBGateway
    {
        void SetColor(int id, Color newColor);
        Color GetColor(int id);
    }
}