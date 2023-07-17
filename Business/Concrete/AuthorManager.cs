using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete;
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

    public AuthorManager(IAuthorDal authorDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper)
    {
        _authorDal = authorDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
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
}
