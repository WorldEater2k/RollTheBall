using UnityEngine;

namespace RollTheBall
{
    internal sealed class UpdateController
    {
        public event MyDelegate OnUpdate;
        public void UpdateAll()
        {
            OnUpdate();
        }
    }
}
