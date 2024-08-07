using Jale_Xanm.Contexts;
using Jale_Xanm.Repositories.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jale_Xanm.Repositories.Implmentations.Generic;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        var entities = _context.Set<T>().AsNoTracking();

        return entities;
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);

        return entity;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
