using System;

namespace RollTheBall
{
    public delegate void FindBonus(int value);
    internal abstract class Bonus : CollectableObject
    {
        public int Value { get; protected set; }
        public event FindBonus BonusFound;
        protected override void Collect()
        {
            _stats.Tokens += Value;
            BonusFound?.Invoke(Value);
        }

        protected (BonusType Type, int Value) GetInfo()
        {
            BonusType type = GetType().Name switch
            {
                "BigBonus" => BonusType.Big,
                "SmallBonus" => BonusType.Small,
                _ => BonusType.Common,
            };
            return (type, Value);
        }
    }

}
