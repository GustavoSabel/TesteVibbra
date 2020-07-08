namespace VibbraTest.Domain.Exceptions
{
    public class AuthenticationException : BusinessException
    {
        public AuthenticationException(string message) : base(message, System.Net.HttpStatusCode.Unauthorized)
        {
            
        }
    }
}
