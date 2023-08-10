using AutoMapper;
using Business.Abstract;
using Business.Abstract.CrudInterfaces;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public IDataResult<IEnumerable<GetBooksDetail>> GetByIdEntity(int id)
    {
        var result = _bookAndCategoryDal.GetX(x => x.Id == id).Include(y => y.Categories).Include(z => z.Books);
        var mapped = result.Select(item => _mapper.Map<GetBooksDetail>(item));
        return new SuccessDataResult<IEnumerable<GetBooksDetail>>(mapped);
    }

    public IDataResult<IEnumerable<GetBooksDetail>> GetListAsync()
    {
        var result = _bookAndCategoryDal.GetAll().Include(x => x.Categories).Include(x => x.Books).ToList();
        var mapped = _mapper.Map<IEnumerable<GetBooksDetail>>(result);
        return new SuccessDataResult<IEnumerable<GetBooksDetail>>(mapped, Messages.Listed);
    }
}
