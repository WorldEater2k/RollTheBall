using UnityEngine;
using static UnityEngine.Debug;

namespace RollTheBall
{
    internal sealed class Mine : CollectableObject
    {
        [SerializeField] private int _damage = 20;
        [SerializeField] private GameObject _effect;
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _force = 700f;
        protected override void Collect()
        {
            GameObject particles = Instantiate(_effect, transform.position, transform.rotation);
            Destroy(particles, 4f);

            foreach (Collider coll in Physics.OverlapSphere(transform.position, _radius))
            {
                Rigidbody rb = coll.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    if (rb.gameObject.CompareTag("Player"))
                        _stats.Health -= _damage;
                    else
                        rb.AddExplosionForce(_force, transform.position, _radius);
                }
            }

            Log("Вы потеряли 20 очков здоровья!");
        }
    }
}
