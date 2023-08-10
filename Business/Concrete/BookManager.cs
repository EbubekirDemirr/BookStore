using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Redis;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.Concrete.Models.BookAndAuthor;
using Entities.Concrete.Models.Books;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class BookManager : IBookService
{
    private readonly IBookDal _bookDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;
    private readonly LibraryContext _libraryContext;
    private readonly IBookAndAuthorDal _bookAndAuthorDal;
    private readonly IBookAndCategoryDal _bookAndCategoryDal;


    public BookManager(IBookDal bookDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper, ICacheService cacheService, LibraryContext libraryContext, IBookAndAuthorDal bookAndAuthorDal, IBookAndCategoryDal bookAndCategoryDal)
    {
        _bookDal = bookDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
        _cacheService = cacheService;
        _libraryContext = libraryContext;
        _bookAndAuthorDal = bookAndAuthorDal;
        _bookAndCategoryDal = bookAndCategoryDal;
    }
    public IResult CreateEntity(CreateBookDTO tEntity)
    {
        var mappedBook = _mapper.Map<Book>(tEntity);
        _bookDal.Insert(mappedBook);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Created);
    }
    public IResult DeleteEntity(DeleteBookDTO tEntity)
    {
        var mappedBook = _mapper.Map<Book>(tEntity);
        _bookDal.Delete(mappedBook);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Deleted);
    }
    public IDataResult<Book> GetByIdEntity(int id)
    {

        return new SuccessDataResult<Book>(_bookDal.GetById(id));
    }
    public IResult UpdateEntity(UpdateBookDTO tEntity)
    {
        var mappedBook = _mapper.Map<Book>(tEntity);
        _bookDal.Update(mappedBook);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Updated);
    }

    public IDataResult<List<BookModel>> Get()
    {
        var cacheData = _cacheService.GetData<List<BookModel>>("GetBook");
        if (cacheData != null)
        {
            return new SuccessDataResult<List<BookModel>>(cacheData);
        }
        var expirationTime = DateTimeOffset.Now.AddDays(5);
        var books = _libraryContext.Books.ToList();
        var bookModels = _mapper.Map<List<BookModel>>(books);
        _cacheService.SetData("GetBook", bookModels, expirationTime);

        return new SuccessDataResult<List<BookModel>>(bookModels);
    }

    public IDataResult<IEnumerable<GetBookDto>> GetListAsync()
    {
        //IEnumerable<Book> books =  _bookDal.GetListAsync();
        //var mappedBook = _mapper.Map<IEnumerable<GetBookDto>>(books);
        //return new SuccessDataResult<IEnumerable<GetBookDto>>(mappedBook, Messages.Listed);
        return null;
    }

    public IDataResult<List<GetBooksDetail>> GetBookByAuthorId(int id)
    {
        var result = _bookAndAuthorDal.GetX(x => x.AuthorId == id).Include(y => y.Books).ToList();
        var mapped = _mapper.Map<List<GetBooksDetail>>(result);
        return new SuccessDataResult<List<GetBooksDetail>>(mapped);
    }
    public IDataResult<List<GetBooksDetail>> GetBookByCategoryId(int id)
    {
        var result = _bookAndCategoryDal.GetX(x => x.CategoryId == id).Include(y => y.Books).ToList();
        var mapped = _mapper.Map<List<GetBooksDetail>>(result);
        return new SuccessDataResult<List<GetBooksDetail>>(mapped);
    }
}
