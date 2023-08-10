using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity, new()
{
    private readonly LibraryContext _libraryContext;

    public GenericRepository(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public void Delete(T entity)
    {
        _libraryContext.Remove(entity);
    }

    public T GetById(int id)
    {
        return _libraryContext.Set<T>().Find(id);
    }

    public void Insert(T entity)
    {
        _libraryContext.Add(entity);
    }

    public void Update(T entity)
    {
        _libraryContext.Update(entity);
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
         return _libraryContext.Set<T>().FirstOrDefault(filter);
    }

    public IQueryable<T> GetX(Expression<Func<T, bool>> filter)
    {
        return _libraryContext.Set<T>().Where(filter);
    }
    public IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null)
    {
       return expression==null ? _libraryContext.Set<T>().AsNoTracking(): _libraryContext.Set<T>().Where(expression).AsNoTracking();
    }

    public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null)
    {
        return expression ==  null ? await _libraryContext.Set<T>().ToListAsync() : await _libraryContext.Set<T>().Where(expression).ToListAsync();
    }
    public IQueryable<T> GetAll()
    {
        return _libraryContext.Set<T>().AsNoTracking().Where(x => x.IsActive).AsQueryable<T>();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _libraryContext.Set<T>().FirstOrDefaultAsync(filter);
    }

    public int SaveChanges()
    {
        return _libraryContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _libraryContext.SaveChangesAsync();
    }
}
