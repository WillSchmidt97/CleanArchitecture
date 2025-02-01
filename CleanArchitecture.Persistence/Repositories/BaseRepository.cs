using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        entity.CreatedDate = DateTimeOffset.UtcNow;
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedDate = DateTimeOffset.UtcNow;
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedDate = DateTimeOffset.UtcNow;
        _context.Remove(entity);
    }

    public async Task<T> Get(Guid Id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == Id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }
}