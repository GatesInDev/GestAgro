using GestAgro.Application.DTOs.EarlyRegister;

namespace GestAgro.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto request, CancellationToken cancellationToken = default);
        Task ConfirmAsync(Guid id, string token, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserDto>> GetPendingAsync(CancellationToken cancellationToken = default);
    }
}