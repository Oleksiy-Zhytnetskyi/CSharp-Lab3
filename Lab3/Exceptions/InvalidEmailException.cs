namespace KMA.CSharp2024.Lab3.Exceptions
{
    public class InvalidEmailException : ApplicationException
    {
        public InvalidEmailException() : base("Error: Invalid email address")
        {
        }

        public InvalidEmailException(string message) : base(message)
        {
        }

        public InvalidEmailException(string message, Exception innerException) : 
            base(message, innerException) 
        {
        }
    }
}
