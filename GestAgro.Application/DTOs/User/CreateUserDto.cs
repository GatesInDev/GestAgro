using System.ComponentModel.DataAnnotations;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Application.DTOs.EarlyRegister
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "O campo nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo nome deve conter ao menos 3 caracteres.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]+$", ErrorMessage = "O campo nome deve conter apenas letras e espaços.")]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "O campo email é inválido.")]
        [MaxLength(255, ErrorMessage = "O campo email é obrigatório.")]
        public string Email { get; set; } = null!;

        [Required]
        [Phone(ErrorMessage = "O campo telefone é inválido.")]
        [MaxLength(20, ErrorMessage = "O campo telefone é obrigatório.")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "O campo região é obrigatório.")]
        [MaxLength(2, ErrorMessage = "O campo região deve seguir o padrão ISO 3166-1 alpha-2.")]
        public string Region { get; set; } = null!;
    }
}