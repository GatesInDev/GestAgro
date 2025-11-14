namespace GestAgro.Domain.Exceptions;

/// <summary>
///     Exceção base abstrata para erros ocorridos dentro da camada de Domínio.
/// </summary>
/// <remarks>
///     Esta classe serve como base para exceções mais específicas das regras de negócio
///     e validações do domínio, como <c>DomainValidationException</c>.
/// </remarks>
public abstract class DomainException : Exception
{
    #region Constructors

    /// <summary>
    ///     Inicializa uma nova instância da classe <see cref="DomainException" />.
    /// </summary>
    protected DomainException()
    {
    }

    /// <summary>
    ///     Inicializa uma nova instância da classe <see cref="DomainException" />
    ///     com uma mensagem de erro específica.
    /// </summary>
    /// <param name="message">A mensagem que descreve o erro.</param>
    protected DomainException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Inicializa uma nova instância da classe <see cref="DomainException" />
    ///     com uma mensagem de erro específica e uma referência à exceção interna.
    /// </summary>
    /// <param name="message">A mensagem que descreve o erro.</param>
    /// <param name="inner">A exceção que é a causa da exceção atual.</param>
    protected DomainException(string message, Exception inner)
        : base(message, inner)
    {
    }

    #endregion
}