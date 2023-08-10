using Business.Abstract.CrudInterfaces;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Models.BookAndAuthor;
using Entities.Concrete.Models.GetModels;

namespace Business.Abstract;

public interface IBookAndAuthorService : IBasicGetListEntity<GetBooksDetail>

{
    IDataResult<IEnumerable<GetBooksDetail>> GetByIdEntity(int id);
}
