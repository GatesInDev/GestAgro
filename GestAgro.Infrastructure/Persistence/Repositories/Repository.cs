using GestAgro.Domain.Interfaces;
using GestAgro.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace GestAgro.Infrastructure.Persistence.Repositories;

public abstract class Repository<TR> : IRepository<TR> where TR : class
{
    private readonly AppDbContext _context;
    protected readonly DbSet<TR> DbSet;

    protected Repository(AppDbContext context)
    {
        _context = context;
        DbSet = _context.Set<TR>();
    }

    public async Task AddAsync(TR entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TR entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TR?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<TR>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }
}