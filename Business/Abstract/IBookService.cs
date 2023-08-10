using Business.Abstract.CrudInterfaces;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.Concrete.Models.BookAndAuthor;
using Entities.Concrete.Models.Books;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;

namespace Business.Abstract;

public interface IBookService : IBasicCreateEntity<CreateBookDTO>, 
    IBasicDeleteEntity<DeleteBookDTO>,
    IBasicUpdateEntity<UpdateBookDTO>,
    IBasicGetByIdEntity<Book , int>,
    IBasicGetListEntity<GetBookDto>

{
    IDataResult<List<BookModel>> Get();
    IDataResult<List<GetBooksDetail>> GetBookByAuthorId(int id);
    IDataResult<List<GetBooksDetail>> GetBookByCategoryId(int id);
}
