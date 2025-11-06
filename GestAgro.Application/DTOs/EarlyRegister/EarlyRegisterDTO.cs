using GestAgro.Domain.Enums.EarlyRegister;

namespace GestAgro.Application.DTOs.EarlyRegister
{
    public class EarlyRegisterDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public EarlyRegisterStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
    }
}