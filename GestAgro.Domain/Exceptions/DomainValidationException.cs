namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Exception que representa um erro de validação na camada de domínio.
    /// </summary>
    public class DomainValidationException : DomainException
    {
        #region Properties

        /// <summary>
        /// Obtém o nome da propriedade que causou o erro de validação.
        /// </summary>
        public string? PropertyName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainValidationException"/>.
        /// </summary>
        public DomainValidationException()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainValidationException"/> 
        /// com uma mensagem de erro específica.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DomainValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainValidationException"/> 
        /// com uma mensagem de erro específica e uma referência à Exception interna.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="inner">A Exception que é a causa da exceção atual.</param>
        public DomainValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainValidationException"/>
        /// com o nome da propriedade e uma mensagem de erro.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade que falhou na validação.</param>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DomainValidationException(string propertyName, string message)
            : base(message)
        {
            this.PropertyName = propertyName;
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainValidationException"/>
        /// com o nome da propriedade, uma mensagem de erro e uma referência à exceção interna.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade que falhou na validação.</param>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="inner">A Exception que é a causa da exceção atual.</param>
        public DomainValidationException(string propertyName, string message, Exception inner)
            : base(message, inner)
        {
            this.PropertyName = propertyName;
        }

        #endregion
    }
}