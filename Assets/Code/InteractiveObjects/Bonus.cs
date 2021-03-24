namespace RollTheBall
{
    public delegate void FindBonus(int value);
    internal abstract class Bonus : CollectableObject
    {
        protected int _value;
        public event FindBonus BonusFound;
        protected override void Collect()
        {
            _stats.Tokens += _value;
            BonusFound?.Invoke(_value);
        }
    }

}
