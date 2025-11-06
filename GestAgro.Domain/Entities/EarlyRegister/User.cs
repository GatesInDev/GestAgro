using GestAgro.Domain.Enums.EarlyRegister;
using GestAgro.Domain.Enums.Generics;
using GestAgro.Domain.Exceptions;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Domain.Entities.EarlyRegister
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public TelephoneNumber PhoneNumber { get; private set; }
        public Country Region { get; private set; }
        public string? VerificationToken { get; private set; }
        public EarlyRegisterStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ConfirmedAt { get; private set; }

        private User(Guid id, string name, Email email, TelephoneNumber phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            Status = EarlyRegisterStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            VerificationToken = Guid.NewGuid().ToString("N");
            PhoneNumber = phoneNumber;
        }

        public static User Create(string name, string email, string phone, string region)
        {
            try
            {
                Email.TryParse(email, out var voEmail);
                TelephoneNumber.TryParse(phone, out var voPhoneNumber, region);

                return new User(Guid.NewGuid(), name, voEmail!, voPhoneNumber!);
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Early Register cannot be completed.");
            }
        }

        public void Confirm(string token)
        {
            if (Status != EarlyRegisterStatus.Pending)
                throw new InvalidOperationException("Pré-cadastro não está em estado Pending.");

            if (string.IsNullOrWhiteSpace(VerificationToken) || token != VerificationToken)
                throw new InvalidOperationException("Token inválido.");

            Status = EarlyRegisterStatus.Confirmed;
            ConfirmedAt = DateTime.UtcNow;
            VerificationToken = null;
        }

        public void Cancel()
        {
            if (Status == EarlyRegisterStatus.Confirmed || Status == EarlyRegisterStatus.ConvertedToUser)
                throw new InvalidOperationException("Não é possível cancelar um pré-cadastro confirmado/convertido.");

            Status = EarlyRegisterStatus.Canceled;
        }
    }
}