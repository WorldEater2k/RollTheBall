using System;

namespace RollTheBall
{
    internal sealed class ParamException : Exception
    {
        public float Value { get; }
        public ParamException() : base("�������� �� ����� ��������� ����� ��������.") { }
        public ParamException(string msg, float value) : base(msg)
        {
            Value = value;
        }
        public ParamException(float value) : this($"�������� �� ����� ��������� �������� {value}.", value) { }
    }
}
