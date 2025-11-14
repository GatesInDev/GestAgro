using System.Globalization;
using GestAgro.Domain.Exceptions;

namespace GestAgro.Domain.ValueObjects;

/// <summary>
///     Representa um ponto no tempo (timestamp) como um Value Object imutável.
/// </summary>
/// <remarks>
///     Esta classe armazena internamente o valor como um <see cref="DateTime" /> em UTC (Tempo Universal Coordenado).
///     A validação espera formatos de data que o <see cref="CultureInfo.InvariantCulture" /> entenda,
///     como o padrão ISO 8601 ("o").
/// </remarks>
public sealed class DateValue
{
    #region Constructor

    /// <summary>
    ///     Construtor privado para forçar a criação através dos métodos de fábrica (Parse/TryParse).
    /// </summary>
    /// <param name="value">O valor DateTime (deve estar em UTC).</param>
    private DateValue(DateTime value)
    {
        Value = value;
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Obtém o valor <see cref="DateTime" /> armazenado, sempre em UTC.
    /// </summary>
    public DateTime Value { get; }

    #endregion

    #region Private Helpers

    /// <summary>
    ///     Lógica central de criação e validação.
    /// </summary>
    private static DateValue Create(string dateString)
    {
        if (string.IsNullOrWhiteSpace(dateString))
            throw new DomainValidationException(nameof(dateString), "A data não pode se vazia.");

        const DateTimeStyles styles = DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal;

        return DateTime.TryParse(dateString, CultureInfo.InvariantCulture, styles, out var parsed)
            ? new DateValue(parsed)
            : throw new DomainValidationException(nameof(dateString), "O formato de data não é válido.");
    }

    #endregion

    #region Static Factory Methods

    /// <summary>
    ///     Converte (Parse) uma string em uma instância de <see cref="DateValue" />.
    ///     Lança uma Exception se a conversão falhar.
    /// </summary>
    /// <param name="input">A string da data/hora a ser analisada.</param>
    /// <returns>Uma nova instância de <see cref="DateValue" />.</returns>
    /// <exception cref="DomainValidationException">Lançada se a entrada for nula, vazia ou inválida.</exception>
    public static DateValue Parse(string input)
    {
        return TryParse(input, out var date)
            ? date!
            : throw new DomainValidationException(nameof(input), "A data não é válida.");
    }

    /// <summary>
    ///     Tenta converter (Try Parse) uma string em uma instância de <see cref="DateValue" />.
    /// </summary>
    /// <param name="input">A string da data/hora a ser analisada.</param>
    /// <param name="date">
    ///     Quando este método retorna, contém o Object <see cref="DateValue" /> analisado
    ///     se a análise foi bem-sucedida, ou <c>null</c> se a análise falhou.
    /// </param>
    /// <returns><c>true</c> se a entrada foi convertida com sucesso; caso contrário, <c>false</c>.</returns>
    public static bool TryParse(string input, out DateValue? date)
    {
        try
        {
            date = Create(input);
            return true;
        }
        catch (DomainValidationException)
        {
            date = null;
            return false;
        }
    }

    #endregion

    #region Overrides & Operators

    /// <summary>
    ///     Retorna a data no formato "Round-trip" (ISO 8601), que inclui o 'Z' de UTC.
    ///     Ex: "2025-11-07T21:45:00.0000000Z"
    /// </summary>
    /// <returns>A string da data formatada.</returns>
    public override string ToString()
    {
        return Value.ToString("o");
    }

    /// <summary>
    ///     Permite a conversão implícita de um <see cref="DateValue" /> para <c>string</c>.
    /// </summary>
    /// <param name="d">O Object <see cref="DateValue" /> a ser convertido.</param>
    public static implicit operator string(DateValue d)
    {
        return d.ToString();
    }

    /// <summary>
    ///     Permite a conversão implícita de um <see cref="DateValue" /> para <see cref="DateTime" />.
    /// </summary>
    /// <param name="d">O Object <see cref="DateValue" /> a ser convertido.</param>
    public static implicit operator DateTime(DateValue d)
    {
        return d.Value;
    }

    #endregion
}