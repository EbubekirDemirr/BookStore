using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IGenericDal<T> where T : class
{

    void Insert(T entity);
    void Delete(T entity);
    void Update(T entity);
    List<T> GetAll();
    T GetById(int id);
    T Get(Expression<Func<T, bool>> filter);
    void MultiUpdate(List<T> entities);

}
