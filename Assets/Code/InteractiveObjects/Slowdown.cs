using static UnityEngine.Debug;

namespace RollTheBall
{
    internal sealed class Slowdown : SpeedBuff
    {
        protected override void Awake()
        {
            base.Awake();
            _speedCoeff = 0.5f;
        }

        protected override void Collect()
        {
            base.Collect();
            Log("���� �������� �������� �� 60 ������!");
        }
    }
}
