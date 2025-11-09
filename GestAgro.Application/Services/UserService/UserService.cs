using GestAgro.Application.DTOs.EarlyRegister;
using GestAgro.Application.Interfaces;
using GestAgro.Domain.Entities;
using GestAgro.Domain.Interfaces;

namespace GestAgro.Application.Services.UserService;

public partial class UserService(IUserRepository repository) : IUserService
{
    private static UserDto ToDto(User e) =>
        new UserDto()
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