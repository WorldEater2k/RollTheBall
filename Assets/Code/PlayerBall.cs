using UnityEngine;

namespace RollTheBall
{
    internal sealed class PlayerBall : Player
    {
        public override void Move(float x, float y)
        {
            _rigidbody.AddForce(new Vector3(x, y, 0) * _stats.Speed, ForceMode.Impulse);
        }
    }

}
