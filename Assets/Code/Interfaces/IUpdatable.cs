using System;

namespace RollTheBall
{
    internal interface IUpdatable : IDisposable
    {
        public void SubscribeToUpdate();
        public void MyUpdate();
    }
}
