using System;

namespace VibbraTest.Domain.Exceptions
{
    public abstract class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
