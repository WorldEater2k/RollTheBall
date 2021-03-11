namespace RollTheBall
{
    internal sealed class BigBonus : Bonus
    {
        protected override void Start()
        {
            base.Start();
            _value = 15;
        }
    }

}
