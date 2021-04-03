using UnityEngine;

namespace RollTheBall
{
    public delegate void PlayerDying();

    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody))]
    internal abstract class Player : MonoBehaviour
    {
        protected PlayerStats _stats;
        protected Rigidbody _rigidbody;
        protected void Awake()
        {
            _stats = References.PlayerStats;
            _rigidbody = GetComponent<Rigidbody>();
        }
        public abstract void Move(float force, Vector3 direction);
    }

}