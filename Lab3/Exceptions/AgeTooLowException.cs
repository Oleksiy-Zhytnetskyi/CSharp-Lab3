namespace KMA.CSharp2024.Lab3.Exceptions
{
    public class AgeTooLowException : ApplicationException
    {
        public AgeTooLowException() : base("Error: Age cannot be lower than 0")
        {
        }

        public AgeTooLowException(string message) : base(message) 
        {
        }

        public AgeTooLowException(string message, Exception innerException) : 
            base(message, innerException)
        {
        }
    }
}
