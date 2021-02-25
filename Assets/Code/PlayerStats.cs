using UnityEngine;

namespace RollTheBall
{
    [CreateAssetMenu(fileName = "New PlayerStats", menuName = "PlayerStats", order = 51)]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private int _health = 100;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _mass = 1f;
        [SerializeField] private int _tokens = 0;

        public event PlayerDying PlayerDeath;
        public bool IsInvulnerable { get; set; } = false;
        public int Health
        {
            get => _health;
            set
            {
                if (!IsInvulnerable)
                {
                    if (value <= 0)
                        PlayerDeath?.Invoke();
                    else
                        _health = value;
                }
            }
        }

        public float Speed
        {
            get => _speed;
            set
            {
                if (value >= 0)
                    _speed = value;
                else
                    throw new ParamException("Скорость не может быть меньше 0.", value);
            }
        }
        public int Tokens
        {
            get => _tokens;
            set
            {
                if (value >= 0)
                    _tokens = value;
                throw new ParamException("Кол-во токенов не может быть меньше 0.", value);
            }
        }
        public float Mass
        {
            get => _mass;
            set
            {
                if (value >= 0)
                    _mass = value;
                throw new ParamException("Масса игрока не может быть меньше 0.", value);
            }
        }
    }
}
