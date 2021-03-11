using static UnityEngine.Debug;

namespace RollTheBall
{
    internal sealed class Slowdown : SpeedBuff
    {
        protected override void Start()
        {
            base.Start();
            _speedCoeff = 0.5f;
        }

        protected override void Collect()
        {
            base.Collect();
            Log("Ваша скорость понижена на 60 секунд!");
        }
    }
}
