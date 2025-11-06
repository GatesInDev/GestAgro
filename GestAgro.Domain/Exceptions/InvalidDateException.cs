namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a date parameter is invalid.
    /// </summary>
    /// <remarks>This exception is typically thrown when a method receives a date argument that does not meet
    /// the expected criteria or format. It extends <see cref="DomainException"/> to provide additional context about
    /// the invalid date parameter.</remarks>
    public class InvalidDateException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDateException"/> class.
        /// </summary>
        public InvalidDateException()
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an invalid date is encountered.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidDateException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an invalid date is encountered.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is
        /// specified.</param>
        public InvalidDateException(string message, Exception inner) 
            : base(message, inner)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when a date parameter is invalid.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        public InvalidDateException(string paramName, string message)
            : base($"Invalid date for parameter '{paramName}': {message}")
        {
        }
    }
}
