namespace VibbraTest.Domain.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException(string message) : base(message + " not found")
        {
        }
    }
}
