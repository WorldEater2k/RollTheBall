using UnityEngine;
using System;

namespace RollTheBall
{
    public delegate void PlayerDying();
    internal abstract class Player : MonoBehaviour
    {
        protected PlayerStats _stats;
        protected void Awake()
        {
            _stats = FindObjectOfType<PlayerStats>();
        }
        protected void Start()
        {
            if (_stats == null)
                throw new NullReferenceException("�������� ��������� ������� PlayerStats!");
        }
        public abstract void Move();
    }

}