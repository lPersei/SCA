using System.Collections.Generic;
using Enities;
using UniRx;
using UnityEngine;

namespace Presenters
{
    public interface ICubePresenter
    {
        List<ReactiveProperty<Cube>> Cubes { get; }
        void ChangeColor(int id, Color color);
    }
}