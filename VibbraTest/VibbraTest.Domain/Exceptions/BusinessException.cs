using System;
using System.Net;

namespace VibbraTest.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public BusinessException(string message, HttpStatusCode statusCode) : this(message)
        {
            HttpStatusCode = statusCode;
        }

        public BusinessException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
        }
    }
}
