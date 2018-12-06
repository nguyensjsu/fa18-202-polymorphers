using System;
using UnityEngine;
namespace Model
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void NotifyObserver();
    }
}
