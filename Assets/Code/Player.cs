using UnityEngine;
using System;

namespace RollTheBall
{
    public delegate void PlayerDying();
    internal abstract class Player : MonoBehaviour
    {
        protected PlayerStats _stats;
        protected Rigidbody _rigidbody;
        protected void Awake()
        {
            _stats = References.PlayerStats;
            _rigidbody = GetComponent<Rigidbody>();
        }
        public abstract void Move(float x, float y);
    }

}