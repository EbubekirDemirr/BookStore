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
    private readonly IBookImageDal _bookImageDal;


    public BookManager(IBookDal bookDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper, ICacheService cacheService, LibraryContext libraryContext, IBookAndAuthorDal bookAndAuthorDal, IBookAndCategoryDal bookAndCategoryDal, IBookImageDal bookImageDal)
    {
        _bookDal = bookDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
        _cacheService = cacheService;
        _libraryContext = libraryContext;
        _bookAndAuthorDal = bookAndAuthorDal;
        _bookAndCategoryDal = bookAndCategoryDal;
        _bookImageDal = bookImageDal;

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

    public IDataResult<List<BookModel>> GetAll()
    {
        var cacheData = _cacheService.GetData<List<BookModel>>("GetBook1");
        if (cacheData != null)
        {
            return new SuccessDataResult<List<BookModel>>(cacheData);
        }
        var expirationTime = DateTimeOffset.Now.AddDays(5);
        var books = _bookDal.GetAll().Include(x=>x.BookImages).ToList();
        var bookModels = _mapper.Map<List<BookModel>>(books);
        _cacheService.SetData("GetBook1", bookModels, expirationTime);

        return new SuccessDataResult<List<BookModel>>(bookModels);
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

    public IDataResult<BookModel> GetBookWithBookImageByBookId(int id)
    {
        var result = _bookDal.GetX(x => x.Id == id).Include(y => y.BookImages).FirstOrDefault();
        var mapped=_mapper.Map<BookModel>(result);
        return new SuccessDataResult<BookModel>(mapped);
    }

    public IDataResult<List<BookModel>> GetSearchedBooks(string bookName)
    {
        var result = _bookDal.GetAll().Include(b => b.BookImages).Where(b=>b.BookName.ToLower().Contains(bookName.ToLower())).ToList();
        var mapped = _mapper.Map<List<BookModel>>(result);
        return new SuccessDataResult<List<BookModel>>(mapped);
    }
}
