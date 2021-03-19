using UnityEngine;

namespace RollTheBall
{
    internal sealed class PlayerBall : Player
    {
        public override void Move(float force, Vector3 direction)
        {
            _rigidbody.AddForce(direction * force * _stats.Speed, ForceMode.Impulse);
        }
    }

}
