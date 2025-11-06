using GestAgro.Application.Interfaces;
using GestAgro.Domain.Entities.EarlyRegister;
using System.Collections.Concurrent;
using GestAgro.Domain.Enums.EarlyRegister;

namespace GestAgro.Infrastructure.Persistence.Repositories
{
    public class InMemoryPreRegistrationRepository : IEarlyRegisterRepository
    {
        private readonly ConcurrentDictionary<Guid, User> _store = new();

        public Task AddAsync(User preRegistration, CancellationToken cancellationToken = default)
        {
            _store.TryAdd(preRegistration.Id, preRegistration);
            return Task.CompletedTask;
        }

        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _store.TryGetValue(id, out var value);
            return Task.FromResult<User?>(value);
        }

        public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var found = _store.Values.FirstOrDefault(x => x.Email.ToString().Equals(email, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(found);
        }

        public Task<IEnumerable<User>> GetPendingAsync(CancellationToken cancellationToken = default)
        {
            var pending = _store.Values.Where(x => x.Status == EarlyRegisterStatus.Pending);
            return Task.FromResult(pending);
        }

        public Task UpdateAsync(User preRegistration, CancellationToken cancellationToken = default)
        {
            _store.AddOrUpdate(preRegistration.Id, preRegistration, (_, __) => preRegistration);
            return Task.CompletedTask;
        }
    }
}