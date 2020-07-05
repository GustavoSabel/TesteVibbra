namespace VibbraTest.API
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {

        }

        public ErrorMessage(string error)
        {
            Error = error;
        }

        public string Error { get; set; }
    }
}
