using UnityEngine;

namespace RollTheBall
{
    internal sealed class SmallBonus : Bonus
    {
        protected override void Awake()
        {
            base.Awake();
            Value = 5;
        }
    }

}
