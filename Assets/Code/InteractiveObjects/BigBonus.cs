namespace RollTheBall
{
    internal sealed class BigBonus : Bonus
    {
        protected override void Awake()
        {
            base.Awake();
            _value = 15;
        }
    }

}
