using GestAgro.Domain.Entities;
using GestAgro.Domain.Enums;
using GestAgro.Domain.Interfaces;
using GestAgro.Domain.ValueObjects;
using GestAgro.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace GestAgro.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetPendingAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(user => user.Status == UserStatus.Pending)
            .ToListAsync(cancellationToken);
    }
}