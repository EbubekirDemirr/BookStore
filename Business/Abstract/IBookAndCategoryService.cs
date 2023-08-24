using Business.Abstract.CrudInterfaces;
using Core.Utilities.Results;
using Entities.Concrete.Models.BookAndAuthor;

namespace Business.Abstract;

public interface IBookAndCategoryService: IBasicGetListEntity<GetBooksDetail>
{
    IDataResult<List<GetBooksDetail>> GetByIdEntity(int id);
}
