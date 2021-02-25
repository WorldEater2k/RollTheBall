using System;

namespace RollTheBall
{
    internal sealed class ParamException : Exception
    {
        public float Value { get; }
        public ParamException() : base("Параметр не может принимать такое значение.") { }
        public ParamException(string msg, float value) : base(msg)
        {
            Value = value;
        }
        public ParamException(float value) : this($"Параметр не может принимать значение {value}.", value) { }
    }
}
