using UnityEngine;

namespace RollTheBall
{
    public delegate void MyDelegate();
    internal sealed class Initializator
    {
        public event MyDelegate OnInitialization;
        public void InitializeAll()
        {
            OnInitialization();
        }
    }
}
