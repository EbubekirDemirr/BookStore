using AutoMapper;
using Business.Abstract;
using Business.Abstract.CrudInterfaces;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models.BookAndAuthor;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class BookAndCategoryManager : IBookAndCategoryService
{
    private readonly IBookAndCategoryDal _bookAndCategoryDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;

    public BookAndCategoryManager(IBookAndCategoryDal bookAndCategoryDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper)
    {
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
        _bookAndCategoryDal = bookAndCategoryDal;
    }
    public IDataResult<List<GetBooksDetail>> GetByIdEntity(int id)
    {
        var result = _bookAndCategoryDal.GetX(x => x.CategoryId == id).AsNoTracking().Include(z => z.Books).Include(z => z.Books.BookImages).Include(x => x.Categories).ToList();
        var mapped = _mapper.Map<List<GetBooksDetail>>(result);
        return new SuccessDataResult<List<GetBooksDetail>>(mapped);
    }

    public IDataResult<IEnumerable<GetBooksDetail>> GetListAsync()
    {
        var result = _bookAndCategoryDal.GetAll().Include(x => x.Categories).Include(x => x.Books).ToList();
        var mapped = _mapper.Map<IEnumerable<GetBooksDetail>>(result);
        return new SuccessDataResult<IEnumerable<GetBooksDetail>>(mapped, Messages.Listed);
    }
}
