using static UnityEngine.Debug;

namespace RollTheBall
{
    internal sealed class Boost : SpeedBuff
    {
        protected override void Start()
        {
            base.Start();
            _speedCoeff = 1.7f;
        }

        protected override void Collect()
        {
            base.Collect();
            Log("Ваша скорость возросла на 60 секунд!");
        }
    }

}
