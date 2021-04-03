using System;

namespace RollTheBall
{
    internal sealed class CommonBonus : Bonus
    {
        protected override void Awake()
        {
            base.Awake();
            _value = 10;
        }
    }
}
