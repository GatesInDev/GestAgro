using System;

namespace GestAgro.Domain.Exceptions.EletronicAdress
{
    /// <summary>
    /// Representa um erro que ocorre quando o e-mail é nulo.
    /// </summary>
    public class NullEletronicAdressException : Exception
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public NullEletronicAdressException()
        {
        }

        /// <summary>
        /// Construtor que aceita uma mensagem de erro personalizada.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public NullEletronicAdressException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Construtor que aceita uma mensagem e um erro interno.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="innerException">A excessão que é a causa do erro atual.</param>
        public NullEletronicAdressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
