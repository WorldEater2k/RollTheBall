using UnityEngine;

namespace RollTheBall
{
    internal sealed class SmallBonus : Bonus
    {
        protected override void Start()
        {
            base.Start();
            _value = 5;
        }
    }

}
