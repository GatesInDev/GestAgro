using GestAgro.Domain.Enums;
using GestAgro.Domain.Exceptions;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Domain.Entities;

/// <summary>
///     Entidade que representa um Usuário no sistema.
/// </summary>
public class User
{
    #region Factory Method

    /// <summary>
    ///     Método de fábrica (Factory) para criar uma nova instância de Usuário,
    ///     garantindo que todos os dados de entrada sejam válidos.
    /// </summary>
    /// <param name="name">O nome do usuário.</param>
    /// <param name="email">O e-mail (string) a ser validado.</param>
    /// <param name="phone">O telefone (string) a ser validado.</param>
    /// <param name="region">O código do país/região (string) a ser validado.</param>
    /// <returns>Uma nova instância de <see cref="User" />.</returns>
    /// <exception cref="DomainValidationException">Lançada se qualquer regra de validação falhar.</exception>
    public static User Create(string name, string email, string phone, string region)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainValidationException(nameof(name), "O nome não pode estar vazio.");

        if (!Email.TryParse(email.Trim().ToLowerInvariant(), out var voEmail))
            throw new DomainValidationException(nameof(email), "O formato do e-mail é inválido.");

        if (!CountryCode.TryParse(region.Trim().ToUpperInvariant(), out var voRegion))
            throw new DomainValidationException(nameof(region), "O formato da região é inválido.");

        if (!TelephoneNumber.TryParse(phone, voRegion.Value, out var voPhoneNumber))
            throw new DomainValidationException(nameof(phone), "O formato do telefone é inválido.");

        return new User(
            Guid.NewGuid(),
            name,
            voEmail!,
            voPhoneNumber!,
            voRegion!
        );
    }

    #endregion

    #region Properties

    /// <summary>
    ///     O identificador único do usuário.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    ///     O nome do usuário.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    ///     O e-mail do usuário (Value Object).
    /// </summary>
    public Email Email { get; private set; }

    /// <summary>
    ///     O número de telefone do usuário (Value Object).
    /// </summary>
    public TelephoneNumber PhoneNumber { get; private set; }

    /// <summary>
    ///     O código do país/região do usuário (Value Object).
    /// </summary>
    public CountryCode Region { get; private set; }

    /// <summary>
    ///     Token de verificação usado para confirmar a conta (ex: e-mail).
    /// </summary>
    public string? VerificationToken { get; private set; }

    /// <summary>
    ///     O status atual do usuário.
    /// </summary>
    public UserStatus Status { get; private set; }

    /// <summary>
    ///     A data e hora (UTC) em que o registro foi criado.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    ///     A data e hora (UTC) em que o registro foi confirmado.
    /// </summary>
    public DateTime? ConfirmedAt { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Construtor privado para ser usado pelo método de fábrica 'Create'.
    /// </summary>
    private User(Guid id, string name, Email email, TelephoneNumber phoneNumber, CountryCode region)
    {
        Id = id;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Region = region;

        VerificationToken = Guid.NewGuid().ToString("N");
        Status = UserStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Construtor vazio privado para uso do EF Core.
    /// </summary>
    private User()
    {
    }

    #endregion

    #region Public Methods

    /// <summary>
    ///     Confirma o registro do usuário usando o token de verificação.
    /// </summary>
    /// <param name="token">O token recebido (ex: por e-mail).</param>
    /// <exception cref="DomainValidationException">Lançada se o token for inválido ou o status não for 'Pendente'.</exception>
    public void Confirm(string token)
    {
        if (Status != UserStatus.Pending)
            throw new DomainValidationException(nameof(Status), "O registro não está mais pendente.");

        if (string.IsNullOrWhiteSpace(VerificationToken) || token != VerificationToken)
            throw new DomainValidationException(nameof(token), "O token de verificação é inválido.");

        Status = UserStatus.Confirmed;
        ConfirmedAt = DateTime.UtcNow;
        VerificationToken = null;
    }

    /// <summary>
    ///     Cancela o registro do usuário.
    /// </summary>
    /// <exception cref="DomainValidationException">Lançada se o usuário já estiver confirmado ou ativo.</exception>
    public void Cancel()
    {
        if (Status == UserStatus.Confirmed || Status == UserStatus.Active)
            throw new DomainValidationException(nameof(Status),
                "Não é possível cancelar um registro já confirmado ou ativo.");

        Status = UserStatus.Canceled;
    }

    #endregion
}