using GestAgro.Domain.Exceptions;
using System.Globalization;

namespace GestAgro.Domain.ValueObjects
{
    /// <summary>
    /// Representa um código de país (Region) de duas letras (ISO 3166-1 alpha-2)
    /// como um Value Object imutável.
    /// </summary>
    public sealed class CountryCode
    {
        #region Properties

        /// <summary>
        /// Obtém o código de país de duas letras, sempre em maiúsculas (ex: "BR").
        /// </summary>
        public string Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor privado para forçar a criação através dos métodos de fábrica (Parse/TryParse).
        /// </summary>
        private CountryCode(string value) => Value = value;

        #endregion

        #region Static Factory Methods

        /// <summary>
        /// Converte (Parse) uma string em uma instância de <see cref="CountryCode"/>.
        /// Lança uma exceção se a conversão falhar.
        /// </summary>
        /// <param name="input">O código de duas letras (ex: "BR", "us").</param>
        /// <returns>Uma nova instância de <see cref="CountryCode"/>.</returns>
        /// <exception cref="DomainValidationException">Lançada se a entrada for nula, vazia ou inválida.</exception>
        public static CountryCode Parse(string input)
        {
            return TryParse(input, out var countryCode)
                ? countryCode!
                : throw new DomainValidationException(nameof(input), "O país é inválido.");
        }

        /// <summary>
        /// Tenta converter (Try Parse) uma string em uma instância de <see cref="CountryCode"/>.
        /// </summary>
        /// <param name="input">O código de duas letras (ex: "BR", "us").</param>
        /// <param name="countryCode">
        /// Quando este método retorna, contém o objeto <see cref="CountryCode"/> analisado
        /// se a análise foi bem-sucedida, ou <c>null</c> se a análise falhou.
        /// </param>
        /// <returns><c>true</c> se a entrada foi convertida com sucesso; caso contrário, <c>false</c>.</returns>
        public static bool TryParse(string input, out CountryCode? countryCode)
        {
            try
            {
                countryCode = Create(input);
                return true;
            }
            catch (DomainValidationException)
            {
                countryCode = null;
                return false;
            }
        }

        #endregion

        #region Overrides & Operators

        /// <summary>
        /// Retorna o código do país.
        /// </summary>
        /// <returns>O código de duas letras.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Permite a conversão implícita de um <see cref="CountryCode"/> para <c>string</c>.
        /// </summary>
        public static implicit operator string(CountryCode c) => c.Value;

        #endregion

        #region Private Helpers

        /// <summary>
        /// Lógica central de criação, validação e normalização.
        /// </summary>
        private static CountryCode Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new DomainValidationException(nameof(input), "O país não pode ser vazio.");

            var normalizedInput = input.ToUpperInvariant();

            try
            {
                var region = new RegionInfo(normalizedInput);
                return new CountryCode(region.Name);
            }
            catch (ArgumentException ex)
            {
                throw new DomainValidationException(nameof(input), "O país nao segue o padrão ISO 3166-1 de código.", ex);
            }
        }

        #endregion
    }
}