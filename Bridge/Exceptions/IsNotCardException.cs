using System;

namespace Bridge.Exceptions
{
    public class IsNotCardException : Exception
    {
        public IsNotCardException()
        {
        }

        public IsNotCardException(string message) : base(message)
        {
        }

        public IsNotCardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}