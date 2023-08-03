using System.Collections.Generic;
using Enities;
using UniRx;
using UnityEngine;

namespace Usecases
{
    public interface IColorUsecase
    {
        List<ReactiveProperty<Cube>> Cubes { get; }
        void ChangeColor(int id, Color color);
    }
}