using GestAgro.Domain.Exceptions;
using PhoneNumbers;

namespace GestAgro.Domain.ValueObjects;

/// <summary>
///     Representa um número de telefone como um Value Object imutável.
/// </summary>
/// <remarks>
///     Esta classe valida e normaliza um número de telefone usando a biblioteca "libphonenumber" do Google.
///     Armazena tanto a entrada original (Raw) quanto o formato normalizado (E164).
/// </remarks>
public sealed class TelephoneNumber
{
    #region Constructor

    /// <summary>
    ///     Construtor privado para forçar a criação através dos métodos de fábrica (Parse/TryParse).
    /// </summary>
    /// <param name="raw">A string de entrada original.</param>
    /// <param name="e164">A string normalizada no formato E.164.</param>
    private TelephoneNumber(string raw, string e164)
    {
        E164 = e164;
        Raw = raw;
    }

    #endregion

    #region Private Helpers

    /// <summary>
    ///     Lógica central de criação e validação.
    /// </summary>
    private static TelephoneNumber Create(string telephoneNumber, string region)
    {
        if (string.IsNullOrWhiteSpace(telephoneNumber))
            throw new DomainValidationException(nameof(telephoneNumber), "O telefone é inválido.");

        if (string.IsNullOrWhiteSpace(region))
            throw new DomainValidationException(nameof(region), "A região é inválida.");

        var phoneUtil = PhoneNumberUtil.GetInstance();

        try
        {
            var parsed = phoneUtil.Parse(telephoneNumber, region);

            if (!phoneUtil.IsValidNumber(parsed))
                throw new DomainValidationException(nameof(telephoneNumber), "O telefone é inválido.");

            var e164 = phoneUtil.Format(parsed, PhoneNumberFormat.E164);
            return new TelephoneNumber(telephoneNumber, e164);
        }
        catch (NumberParseException ex)
        {
            throw new DomainValidationException(nameof(telephoneNumber), "O telefone é inválido.", ex);
        }
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Obtém o número de telefone no formato padronizado E.164 (ex: +551155554444).
    /// </summary>
    public string E164 { get; }

    /// <summary>
    ///     Obtém a string original (não processada) fornecida na criação.
    ///     Útil para auditoria ou para exibir a entrada original do usuário.
    /// </summary>
    public string Raw { get; }

    #endregion

    #region Static Factory Methods

    /// <summary>
    ///     Converte (Parse) uma string em uma instância de <see cref="TelephoneNumber" />.
    ///     Lança uma Exception se a conversão falhar.
    /// </summary>
    /// <param name="input">A string do número de telefone a ser analisada.</param>
    /// <param name="region">
    ///     O código de região ISO 3166-1 de dois dígitos (ex: "BR", "US").
    ///     Padrão é "BR".
    /// </param>
    /// <returns>Uma nova instância de <see cref="TelephoneNumber" />.</returns>
    /// <exception cref="DomainValidationException">Lançada se a entrada for inválida ou não puder ser convertida.</exception>
    public static TelephoneNumber Parse(string input, string region = "BR")
    {
        return TryParse(input, region, out var phoneNumber)
            ? phoneNumber!
            : throw new DomainValidationException(nameof(input), "Phone number isn't valid.");
    }

    /// <summary>
    ///     Tenta converter (Parse) uma string em uma instância de <see cref="TelephoneNumber" />.
    /// </summary>
    /// <param name="input">A string do número de telefone a ser analisada.</param>
    /// <param name="region">O código de região ISO 3166-1 de dois dígitos (ex: "BR", "US").</param>
    /// <param name="number">
    ///     Quando este método retorna, contém o Object <see cref="TelephoneNumber" /> analisado
    ///     se a análise foi bem-sucedida, ou <c>null</c> se a análise falhou.
    /// </param>
    /// <returns><c>true</c> se a entrada foi convertida com sucesso; caso contrário, <c>false</c>.</returns>
    public static bool TryParse(string input, string region, out TelephoneNumber? number)
    {
        try
        {
            number = Create(input, region);
            return true;
        }
        catch (DomainValidationException)
        {
            number = null;
            return false;
        }
    }

    /// <summary>
    ///     Cria uma instância de TelephoneNumber a partir de uma string E.164 formatada.
    ///     Este método é útil para reidratação do banco de dados.
    /// </summary>
    /// <param name="e164Number">O número em formato E.164 (ex: +5511...)</param>
    /// <returns>Uma nova instância de TelephoneNumber.</returns>
    /// <exception cref="DomainValidationException">Lançada se o formato E.164 for inválido.</exception>
    public static TelephoneNumber FromE164(string e164Number)
    {
        if (string.IsNullOrWhiteSpace(e164Number) || !e164Number.StartsWith("+"))
            throw new DomainValidationException(nameof(e164Number), "Número deve estar no formato E.164.");

        var phoneUtil = PhoneNumberUtil.GetInstance();
        try
        {
            // Passamos 'null' como região, pois o E.164 é autossuficiente.
            var parsed = phoneUtil.Parse(e164Number, null);

            // Ao reidratar, não temos mais o "Raw" original.
            // Podemos definir 'Raw' como o próprio E.164.
            return new TelephoneNumber(e164Number, e164Number);
        }
        catch (NumberParseException ex)
        {
            throw new DomainValidationException(nameof(e164Number), "Falha ao analisar o número E.164.", ex);
        }
    }

    #endregion

    #region Overrides & Operators

    /// <summary>
    ///     Retorna a representação em string do número de telefone no formato E.164.
    /// </summary>
    /// <returns>O número de telefone no formato E.164.</returns>
    public override string ToString()
    {
        return E164;
    }

    /// <summary>
    ///     Permite a conversão implícita de um <see cref="TelephoneNumber" /> para <c>string</c>.
    /// </summary>
    /// <param name="e">O Object <see cref="TelephoneNumber" /> a ser convertido.</param>
    public static implicit operator string(TelephoneNumber e)
    {
        return e.E164;
    }

    #endregion
}