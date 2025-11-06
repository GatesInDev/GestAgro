namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a phone number is invalid.
    /// </summary>
    /// <remarks>This exception is typically thrown when a method encounters a phone number that does not meet
    /// the expected format or validation criteria. It extends <see cref="DomainException"/> to indicate that the
    /// invalid phone number is related to an argument passed to a method.</remarks>
    public class InvalidPhoneException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPhoneException"/> class.
        /// </summary>
        public InvalidPhoneException()
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an invalid phone number is encountered.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidPhoneException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an invalid phone is encountered.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is
        /// specified.</param>
        public InvalidPhoneException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when a phone parameter is invalid.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        public InvalidPhoneException(string paramName, string message)
            : base($"Invalid phone number for parameter '{paramName}': {message}")
        {
        }
    }
}
