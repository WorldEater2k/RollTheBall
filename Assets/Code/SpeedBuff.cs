namespace RollTheBall
{
    internal abstract class SpeedBuff : CollectableObject
    {
        protected float _speedCoeff;
        protected override void Collect()
        {
            _stats.Speed *= _speedCoeff;
        }
    }

}
