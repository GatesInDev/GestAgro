namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Abstract base class for domain exceptions.
    /// </summary>
    public abstract class DomainException : Exception
    {
        /// <summary>
        /// Constructor for DomainException.
        /// </summary>
        protected DomainException()
        {
        }

        /// <summary>
        /// Constructor for DomainException with message.
        /// </summary>
        /// <param name="message">Message fo base.</param>
        protected DomainException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor for DomainException with message and inner exception.
        /// </summary>
        /// <param name="message">Message for base.</param>
        /// <param name="inner">Inner for base.</param>
        protected DomainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
