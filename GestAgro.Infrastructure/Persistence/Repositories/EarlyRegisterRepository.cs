using GestAgro.Domain.Entities;
using GestAgro.Domain.Enums;
using GestAgro.Domain.Interfaces;
using GestAgro.Domain.ValueObjects;
using GestAgro.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace GestAgro.Infrastructure.Persistence.Repositories
{
    public class EarlyRegisterRepository(AppDbContext context) : IUserRepository
    {

        public async Task AddAsync(User preRegistration, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(preRegistration, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Users
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
        {
            return await context.Users
                .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetPendingAsync(CancellationToken cancellationToken = default)
        {
            return await context.Users
                .Where(user => user.Status == UserStatus.Pending)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(User preRegistration, CancellationToken cancellationToken = default)
        {
            context.Users.Update(preRegistration);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}