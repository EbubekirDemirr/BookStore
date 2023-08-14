using AutoMapper;
using Business.Abstract;
using Business.Abstract.CrudInterfaces;
using Business.Constant;
using Core.Redis;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using System.Linq;

namespace Business.Concrete;

public class AuthorManager: IAuthorService
{
    private readonly IAuthorDal _authorDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;
    private readonly LibraryContext _libraryContext;

    public AuthorManager(IAuthorDal authorDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper, ICacheService cacheService, LibraryContext libraryContext)
    {
        _authorDal = authorDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
        _cacheService = cacheService;
        _libraryContext = libraryContext;
    }

    public IResult CreateEntity(CreateAuthorDTO tEntity)
    {
        var mappedAuthor = _mapper.Map<Author>(tEntity);
        _authorDal.Insert(mappedAuthor);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Created);
    }

    public IResult DeleteEntity(DeleteAuthorDTO tEntity)
    {
        var mappedAuthor = _mapper.Map<Author>(tEntity);
        _authorDal.Delete(mappedAuthor);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Deleted);
    }

    public IDataResult<Author> GetByIdEntity(int id)
    {
        
        return new SuccessDataResult<Author>(_authorDal.GetById(id));
    }

    public IResult UpdateEntity(UpdateAuthorDTO tEntity)
    {
        var mappedAuthor = _mapper.Map<Author>(tEntity);
        _authorDal.Update(mappedAuthor);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Updated);
    }

    public IDataResult<List<AuthorModel>> Get()
    {
        var cacheData = _cacheService.GetData<List<AuthorModel>>("GetAuthor");
        if (cacheData != null)
        {
            return new SuccessDataResult<List<AuthorModel>>(cacheData);
        }
        var expirationTime = DateTimeOffset.Now.AddDays(5);
        var authors = _libraryContext.Authors.ToList();
        var authorModels = _mapper.Map<List<AuthorModel>>(authors);
        _cacheService.SetData("GetAllTest1", authorModels, expirationTime);

        return new SuccessDataResult<List<AuthorModel>>(authorModels);
    }

   
}
