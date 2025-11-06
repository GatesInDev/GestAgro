using GestAgro.Domain.Enums.Generics;

namespace GestAgro.Application.DTOs.EarlyRegister
{
    public class CreateEarlyRegisterRequestDTO
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public Country Region { get; set; } = Country.Brazil;
    }
}