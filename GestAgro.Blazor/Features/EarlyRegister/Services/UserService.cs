using GestAgro.Shared.DTOs.User;

namespace GestAgro.Blazor.Features.EarlyRegister.Services;

public class UserService(HttpClient httpClient) : IUserService
{
    public async Task CreateUser(CreateUserDto user)
    {
        var response = await httpClient.PostAsJsonAsync("api/user", user);
        response.EnsureSuccessStatusCode();
    }
}