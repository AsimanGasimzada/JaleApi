using System.Linq.Expressions;

namespace Jale_Xanm.Repositories.Interfaces.Generic;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);
    Task CreateAsync(T entity);
    void Delete(T entity);
    void Update(T entity);

    Task<int> SaveChangesAsync();
}
