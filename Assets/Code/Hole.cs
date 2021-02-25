using UnityEngine;

namespace RollTheBall
{
    internal sealed class Hole : MonoBehaviour
    {
        public event PlayerDying PlayerDeath;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                PlayerDeath?.Invoke();
        }
    }
}
