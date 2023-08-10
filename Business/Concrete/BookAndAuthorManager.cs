using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete.Models.BookAndAuthor;
using Microsoft.EntityFrameworkCore;

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

    public IDataResult<IEnumerable <GetBooksDetail>> GetByIdEntity(int id)
    {
        var result = _bookAndAuthorDal.GetX(x => x.Id == id).Include(y => y.Authors).Include(z => z.Books);
        var mapped = result.Select(item => _mapper.Map<GetBooksDetail>(item));
        return new SuccessDataResult<IEnumerable<GetBooksDetail>>(mapped);
    }

    public  IDataResult<IEnumerable<GetBooksDetail>> GetListAsync()
    {
        var result =  _bookAndAuthorDal.GetAll().Include(x => x.Authors).Include(x => x.Books).ToList();
        var mapped= _mapper.Map<IEnumerable<GetBooksDetail>>(result);
        return new SuccessDataResult<IEnumerable<GetBooksDetail>>(mapped, Messages.Listed);
    }
}
