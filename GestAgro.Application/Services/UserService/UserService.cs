using GestAgro.Application.Interfaces;
using GestAgro.Domain.Entities;
using GestAgro.Domain.Interfaces;
using GestAgro.Shared.DTOs.User;

namespace GestAgro.Application.Services.UserService;

public partial class UserService(IUserRepository repository) : IUserService
{
    private static UserDto ToDto(User e)
    {
        return new UserDto
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            PhoneNumber = e.PhoneNumber,
            Region = e.Region,
            Status = e.Status,
            CreatedAt = e.CreatedAt,
            ConfirmedAt = e.ConfirmedAt
        };
    }
}