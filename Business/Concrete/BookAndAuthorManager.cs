using AutoMapper;
using Business.Abstract;
using Business.Abstract.CrudInterfaces;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models.Authors;
using Entities.Concrete.Models.BookAndAuthor;
using Entities.Concrete.Models.BookImages;
using Entities.Concrete.Models.Books;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Business.Concrete;

public class BookAndAuthorManager : IBookAndAuthorService
{
    private readonly IBookAndAuthorDal _bookAndAuthorDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;

    public BookAndAuthorManager(IBookAndAuthorDal bookAndAuthorDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper)
    {
        _bookAndAuthorDal = bookAndAuthorDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
    }

    public IDataResult<List<GetBooksDetail>> GetByIdEntity(int id)
    {
        var result = _bookAndAuthorDal.GetX(x => x.AuthorId == id).AsNoTracking().Include(z => z.Books).Include(z => z.Books.BookImages).Include(x => x.Authors).ToList();
        var mapped = _mapper.Map<List<GetBooksDetail>>(result);
        return new SuccessDataResult<List<GetBooksDetail>>(mapped);
    }

    public IDataResult<IEnumerable<GetBooksDetail>> GetListAsync()
    {
        var result = _bookAndAuthorDal.GetAll().Include(x => x.Authors).Include(x => x.Books).ToList();
        var mapped = _mapper.Map<IEnumerable<GetBooksDetail>>(result);
        return new SuccessDataResult<IEnumerable<GetBooksDetail>>(mapped, Messages.Listed);
    }
}
