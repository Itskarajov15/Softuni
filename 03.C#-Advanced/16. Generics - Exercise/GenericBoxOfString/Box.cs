using System;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            Type valueType = Value.GetType();
            string valueTypeFullName = valueType.FullName;

            return $"{valueTypeFullName}: {this.Value}";
        }
    }
}
