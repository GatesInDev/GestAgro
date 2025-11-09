using GestAgro.Domain.Enums;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Application.DTOs.EarlyRegister
{
    public class UserDto
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public CountryCode Region { get; set; } = CountryCode.Parse("BR");
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
    }
}