using GestAgro.Domain.ValueObjects;

namespace GestAgro.Application.DTOs.EarlyRegister
{
    public class CreateEarlyRegisterRequestDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public CountryCode Region { get; set; } = CountryCode.Parse("BR");
    }
}