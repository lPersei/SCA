using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SCA
{
    public interface ICubePresenter
    {
        List<ReactiveProperty<Cube>> Cubes { get; }
        void ChangeColor(int index, Color color);
    }
}