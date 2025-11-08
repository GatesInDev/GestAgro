using GestAgro.Application.DTOs.EarlyRegister;

namespace GestAgro.Application.Interfaces
{
    public interface IUserService
    {
        Task<EarlyRegisterDto> CreateAsync(CreateEarlyRegisterRequestDto request, CancellationToken cancellationToken = default);
        Task<bool> ConfirmAsync(Guid id, string token, CancellationToken cancellationToken = default);
        Task<IEnumerable<EarlyRegisterDto>> GetPendingAsync(CancellationToken cancellationToken = default);
    }
}