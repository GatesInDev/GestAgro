namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Exceção base para erros ocorridos durante a execução da camada de serviço.
    /// </summary>
    /// <remarks>
    /// Esta classe abstrata serve como base para exceções mais específicas da lógica de aplicação,
    /// como <c>DuplicateEmailException</c> ou <c>EntityNotFoundException</c>.
    /// </remarks>
    public abstract class ServiceException : Exception
    {
        #region Constructors

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ServiceException"/>.
        /// </summary>
        protected ServiceException()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ServiceException"/> 
        /// com uma mensagem de erro específica.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        protected ServiceException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ServiceException"/> 
        /// com uma mensagem de erro específica e uma referência à exceção interna.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.</param>
        protected ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}