namespace GestAgro.Domain.Exceptions
{
    /// <summary>
    /// Representa a exceção que é lançada quando uma operação tenta
    /// criar ou atualizar uma entidade com um endereço de e-mail que já existe no sistema.
    /// </summary>
    public class DuplicateEmailException : ServiceException
    {
        #region Properties

        /// <summary>
        /// Opcionalmente, armazena o nome da propriedade que está associada ao erro de e-mail duplicado (ex: "Email").
        /// </summary>
        public string? Property;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DuplicateEmailException"/>.
        /// </summary>
        public DuplicateEmailException()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DuplicateEmailException"/> com uma mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DuplicateEmailException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DuplicateEmailException"/> com uma mensagem de erro especificada
        /// e uma referência à exceção interna que é a causa desta exceção.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="inner">A exceção que é a causa da exceção atual, ou uma referência nula se nenhuma exceção interna for especificada.</param>
        public DuplicateEmailException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DuplicateEmailException"/> com o nome da propriedade
        /// e uma mensagem de erro específica.
        /// </summary>
        /// <param name="property">O nome da propriedade que causou o erro de duplicidade.</param>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DuplicateEmailException(string property, string message)
            : base(message)
        {
            this.Property = property;
        }

        #endregion
    }
}