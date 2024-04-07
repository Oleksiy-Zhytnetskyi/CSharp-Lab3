using KMA.CSharp2024.Lab3.Constants;

namespace KMA.CSharp2024.Lab3.Exceptions
{
    public class AgeTooHighException : ApplicationException
    {
        public AgeTooHighException() : 
            base($"Error: Age cannot be higher than {ApplicationConstants.AGE_THRESHOLD}")
        {
        }

        public AgeTooHighException(string message) : base(message) 
        { 
        }

        public AgeTooHighException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
