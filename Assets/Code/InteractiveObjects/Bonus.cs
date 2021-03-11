namespace RollTheBall
{
    public delegate void FindBonus(int value);
    internal class Bonus : CollectableObject
    {
        protected int _value = 10;
        public event FindBonus BonusFound;
        protected override void Collect()
        {
            _stats.Tokens += _value;
            BonusFound?.Invoke(_value);
        }
    }

}
