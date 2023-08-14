using Business.Abstract.CrudInterfaces;
using Core.Utilities.Results;
using Entities.Concrete.Models.BookAndAuthor;

namespace Business.Abstract;

public interface IBookAndCategoryService: IBasicGetListEntity<GetBooksDetail>
{
    IDataResult<IEnumerable<GetBooksDetail>> GetByIdEntity(int id);
}
