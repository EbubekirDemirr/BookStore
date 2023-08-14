
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Models.Books;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract;

public interface IBookImageService
{
    IDataResult<List<BookImage>> GetAll();
    IDataResult<List<BookImage>> GetByBookId(int bookId);
    IDataResult<BookImage> GetByImageId(int imageId);

    Core.Utilities.Results.IResult Add(IFormFile formFile, CreateBookImageDto bookImage);
}
