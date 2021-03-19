using UnityEngine;
using System;

namespace RollTheBall
{
    internal abstract class CollectableObject : MonoBehaviour, IUpdatable
    {
        [SerializeField] protected float _rotationSpeed = 50f;
        protected PlayerStats _stats;
        protected virtual void Awake()
        {
            _stats = References.PlayerStats;
            SubscribeToUpdate();
        }
        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Collect();
                Destroy(gameObject);
            }
        }
        protected void OnDestroy()
        {
            Dispose();
        }
        protected abstract void Collect();

        public void SubscribeToUpdate()
        {
            References.UpdateController.OnUpdate += MyUpdate;
        }

        public void MyUpdate()
        {
            gameObject.transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime, Space.Self);
        }

        public void Dispose()
        {
            References.UpdateController.OnUpdate -= MyUpdate;
        }
    }

}
