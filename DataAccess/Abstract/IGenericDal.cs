using Entities.Concrete.BaseEntities;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IGenericDal<T> where T : BaseEntity, new()
{ 
    void Insert(T entity);
    void Delete(T entity);
    void Update(T entity);

    T GetById(int id);

    IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);

    int SaveChanges();
    Task<int> SaveChangesAsync();

    IQueryable<T> GetAll();
    IQueryable<T> GetX(Expression<Func<T, bool>> filter);
    T Get(Expression<Func<T, bool>> filter);
}
