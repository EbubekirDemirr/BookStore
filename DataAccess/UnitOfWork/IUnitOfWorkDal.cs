using Entities.Concrete.Authentication;

namespace DataAccess.UnitOfWork;

public interface IUnitOfWorkDal
{
    void Save();
    Task SaveAsync();
    
}
