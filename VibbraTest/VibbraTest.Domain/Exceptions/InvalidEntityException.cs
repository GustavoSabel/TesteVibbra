using System;

namespace VibbraTest.Domain.Exceptions
{
    public class InvalidEntityException : BusinessException
    {
        public InvalidEntityException(string message) : base(message)
        {
        }
    }
}
