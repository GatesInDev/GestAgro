using GestAgro.Domain.Entities.EarlyRegister;

namespace GestAgro.Application.Interfaces
{
    public interface IEarlyRegisterRepository
    {
        Task AddAsync(User preRegistration, CancellationToken cancellationToken = default);
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetPendingAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(User preRegistration, CancellationToken cancellationToken = default);
    }
}