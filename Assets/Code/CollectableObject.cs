using UnityEngine;
using System;

namespace RollTheBall
{
    internal abstract class CollectableObject : MonoBehaviour
    {
        protected PlayerStats _stats;
        protected void Awake()
        {
            _stats = FindObjectOfType<PlayerStats>();
        }
        protected virtual void Start()
        {
            if (_stats == null)
                throw new NullReferenceException("Создайте экземпляр объекта PlayerStats!");
        }
        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Collect();
                Destroy(gameObject);
            }
        }
        protected abstract void Collect();

    }

}
