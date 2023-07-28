using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
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

    public List<T> GetAll()
    {
        return _libraryContext.Set<T>().ToList();
    }

    public void Insert(T entity)
    {
        _libraryContext.Add(entity);
    }

    public void MultiUpdate(List<T> entities)
    {
        _libraryContext.UpdateRange(entities);
    }

    public void Update(T entity)
    {
        _libraryContext.Update(entity);
    }

    public T Get(T entity)
    {
        return _libraryContext.Set<T>().FirstOrDefault();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
         return _libraryContext.Set<T>().FirstOrDefault(filter);
    }
}
