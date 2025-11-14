using System.Net.Mail;
using GestAgro.Domain.Exceptions;

namespace GestAgro.Domain.ValueObjects;

/// <summary>
///     Representa um endereço de e-mail como um Value Object imutável.
/// </summary>
/// <remarks>
///     Esta classe usa <see cref="MailAddress" /> (pattern.NET) para validação
///     e normalização, garantindo que o formato esteja correto e o domínio
///     seja armazenado em minúsculas (ex: "User@DOMAIN.COM" é armazenado como "User@domain.com").
/// </remarks>
public sealed class Email
{
    #region Constructor

    /// <summary>
    ///     Construtor privado para forçar a criação através dos métodos de fábrica (Parse/TryParse).
    /// </summary>
    /// <param name="value">O e-mail normalizado.</param>
    private Email(string value)
    {
        Value = value;
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Obtém o valor do e-mail normalizado (domínio em minúsculas).
    /// </summary>
    public string Value { get; }

    #endregion

    #region Private Helpers

    /// <summary>
    ///     Lógica central de criação, validação e normalização.
    /// </summary>
    private static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainValidationException(nameof(email), "O e-mail não pode ser vazio.");

        return MailAddress.TryCreate(email, out var mailAddress)
            ? new Email(mailAddress.Address)
            : throw new DomainValidationException(nameof(email), "O formato do e-mail é inválido.");
    }

    #endregion

    #region Static Factory Methods

    /// <summary>
    ///     Converte (Parse) uma string em uma instância de <see cref="Email" />.
    ///     Lança uma Exception se a conversão falhar.
    /// </summary>
    /// <param name="input">A string do e-mail a ser analisada.</param>
    /// <returns>Uma nova instância de <see cref="Email" />.</returns>
    /// <exception cref="DomainValidationException">Lançada se a entrada for nula, vazia ou inválida.</exception>
    public static Email Parse(string input)
    {
        return TryParse(input, out var email)
            ? email!
            : throw new DomainValidationException(nameof(input), "O e-mail não é valido.");
    }

    /// <summary>
    ///     Tenta converter (Try Parse) uma string em uma instância de <see cref="Email" />.
    /// </summary>
    /// <param name="input">A string do e-mail a ser analisada.</param>
    /// <param name="email">
    ///     Quando este método retorna, contém o Object <see cref="Email" /> analisado
    ///     se a análise foi bem-sucedida, ou <c>null</c> se a análise falhou.
    /// </param>
    /// <returns><c>true</c> se a entrada foi convertida com sucesso; caso contrário, <c>false</c>.</returns>
    public static bool TryParse(string input, out Email? email)
    {
        try
        {
            email = Create(input);
            return true;
        }
        catch (DomainValidationException)
        {
            email = null;
            return false;
        }
    }

    #endregion

    #region Overrides & Operators

    /// <summary>
    ///     Retorna a representação em string do e-mail.
    /// </summary>
    /// <returns>O valor do e-mail.</returns>
    public override string ToString()
    {
        return Value;
    }

    /// <summary>
    ///     Permite a conversão implícita de um <see cref="Email" /> para <c>string</c>.
    /// </summary>
    /// <param name="e">O Object <see cref="Email" /> a ser convertido.</param>
    public static implicit operator string(Email e)
    {
        return e.Value;
    }

    #endregion
}