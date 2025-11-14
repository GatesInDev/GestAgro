namespace GestAgro.Domain.Exceptions;

/// <summary>
///     Representa a exceção que é lançada quando uma entidade ou recurso específico
///     não é encontrado no sistema.
/// </summary>
public class NotFoundException : ServiceException
{
    #region Constructors

    /// <summary>
    ///     Inicializa uma nova instância da classe <see cref="NotFoundException" /> com uma mensagem padrão.
    /// </summary>
    public NotFoundException()
        : base("O recurso solicitado não foi encontrado.")
    {
    }

    /// <summary>
    ///     Inicializa uma nova instância da classe <see cref="NotFoundException" /> com uma mensagem de erro especificada.
    /// </summary>
    /// <param name="message">A mensagem que descreve o erro.</param>
    public NotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Inicializa uma nova instância da classe <see cref="NotFoundException" /> com uma mensagem de erro especificada
    ///     e uma referência à exceção interna que é a causa desta exceção.
    /// </summary>
    /// <param name="message">A mensagem que descreve o erro.</param>
    /// <param name="inner">
    ///     A exceção que é a causa da exceção atual, ou uma referência nula se nenhuma exceção interna for
    ///     especificada.
    /// </param>
    public NotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }

    #endregion
}