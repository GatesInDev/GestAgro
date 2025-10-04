using GestAgro.Domain.Enums.PreRegistration;

namespace GestAgro.Domain.Entities.PreRegistration
{
    public class PreRegistration
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string EletronicAdress { get; private set; }
        public string? VerificationToken { get; private set; }
        public PreRegistrationStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ConfirmedAt { get; private set; }

        private PreRegistration(Guid id, string name, string eletronicAdress)
        {
            Id = id;
            Name = name;
            EletronicAdress = eletronicAdress;
            Status = PreRegistrationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            VerificationToken = Guid.NewGuid().ToString("N");
        }

        public static PreRegistration Create(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name not can't is empty.");
            if (string.IsNullOrWhiteSpace(email)) 
                throw new ArgumentNullException(nameof(email), "Email not can't is empty");

            return new PreRegistration(Guid.NewGuid(), name, email);
        }
    }
}
