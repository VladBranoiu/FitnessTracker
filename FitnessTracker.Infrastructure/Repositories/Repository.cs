using FitnessTracker.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitnessTracker.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly FitnessTrackerContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(FitnessTrackerContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => _dbSet.Where(predicate).ToListAsync();

    public Task<List<T>> GetAllAsync()
        => _dbSet.ToListAsync();

    public Task<T?> GetByIdAsync(int id)
        => _dbSet.FindAsync(id).AsTask();

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public Task SaveChangesAsync()
        => _context.SaveChangesAsync();
}
