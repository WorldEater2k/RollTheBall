namespace RollTheBall
{
    internal sealed class BigBonus : Bonus
    {
        protected override void Awake()
        {
            base.Awake();
            Value = 15;
        }
    }

}
