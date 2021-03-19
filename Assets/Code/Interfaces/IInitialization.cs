using System;

namespace RollTheBall
{
    internal interface IInitialization : IDisposable
    {
        public void SubscribeToInit();
        public void Init();
    }
}
