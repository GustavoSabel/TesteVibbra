namespace VibbraTest.API
{
    public class ErrorMessage
    {
        public ErrorMessage(string error)
        {
            Error = error;
        }

        public ErrorMessage(string error, FieldValidation[] fieldValidations)
        {
            Error = error;
            FieldValidations = fieldValidations;
        }

        public string Error { get; set; }

        public FieldValidation[] FieldValidations { get; set; }
    }

    public class FieldValidation
    {
        public FieldValidation(string field, string error)
        {
            Field = field;
            Error = error;
        }

        public string Field { get; set; }
        public string Error { get; set; }
    }
}
