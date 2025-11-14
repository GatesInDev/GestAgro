using GestAgro.Shared.DTOs.User;

namespace GestAgro.Blazor.Features.EarlyRegister.Services;

public interface IUserService
{
    Task CreateUser(CreateUserDto user);
}