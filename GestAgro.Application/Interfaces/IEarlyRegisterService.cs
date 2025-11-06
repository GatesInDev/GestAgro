using GestAgro.Application.DTOs.EarlyRegister;

namespace GestAgro.Application.Interfaces
{
    public interface IEarlyRegisterService
    {
        Task<EarlyRegisterDTO> CreateAsync(CreateEarlyRegisterRequestDTO request, CancellationToken cancellationToken = default);
        Task<bool> ConfirmAsync(Guid id, string token, CancellationToken cancellationToken = default);
        Task<IEnumerable<EarlyRegisterDTO>> GetPendingAsync(CancellationToken cancellationToken = default);
    }
}