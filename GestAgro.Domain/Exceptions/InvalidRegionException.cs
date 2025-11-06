namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a phone number is invalid.
    /// </summary>
    /// <remarks>This exception is typically thrown when a method encounters a phone number that does not meet
    /// the expected format or validation criteria. It extends <see cref="DomainException"/> to indicate that the
    /// invalid phone number is related to an argument passed to a method.</remarks>
    public class InvalidRegionException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRegionException"/> class.
        /// </summary>
        public InvalidRegionException()
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an invalid region is encountered.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidRegionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an invalid region is encountered.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is
        /// specified.</param>
        public InvalidRegionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when a region parameter is invalid.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error.</param>
        public InvalidRegionException(string paramName, string message)
            : base($"Invalid region for parameter '{paramName}': {message}")
        {
        }
    }
}
