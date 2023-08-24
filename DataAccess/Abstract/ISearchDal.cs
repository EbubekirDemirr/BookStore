using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ISearchDal
{
     IQueryable GetSearchedData();

}

