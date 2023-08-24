using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.EmailSender;
using Core.Redis;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Microsoft.EntityFrameworkCore;
using static StackExchange.Redis.Role;

namespace Business.Concrete;

public class CategoryManager: ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;
    private readonly LibraryContext _libraryContext;


    public CategoryManager(ICategoryDal categoryDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper, ICacheService cacheService, LibraryContext libraryContext)
    {
        _categoryDal = categoryDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;      
        _cacheService = cacheService;
        _libraryContext = libraryContext;
    }

    public IResult CreateEntity(CreateCategoryDTO tEntity)
    {
       var mappedCategory = _mapper.Map<Category>(tEntity);
       _categoryDal.Insert(mappedCategory);      
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Created);
    }

    public IResult DeleteEntity(DeleteCategoryDTO tEntity)
    {
        var mappedCategory = _mapper.Map<Category>(tEntity);
        _categoryDal.Delete(mappedCategory);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Deleted);
    }


    public IResult UpdateEntity(UpdateCategoryDTO tEntity)
    {
        var mappedCategory = _mapper.Map<Category>(tEntity);
        _categoryDal.Update(mappedCategory);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Updated);
    }


    public IDataResult<List<CategoryModel>> Get()
    {
        var cacheData = _cacheService.GetData<List<CategoryModel>>("GetCategory");
        if (cacheData != null)
        {
            return new SuccessDataResult<List<CategoryModel>>(cacheData);
        }
        var expirationTime = DateTimeOffset.Now.AddDays(5);
        var categories = _libraryContext.Categories.ToList();
        var categoryModels = _mapper.Map<List<CategoryModel>>(categories);
        _cacheService.SetData("GetCategory", categoryModels, expirationTime);

        return new SuccessDataResult<List<CategoryModel>>(categoryModels);
    }
    public IDataResult<Category> GetByIdEntity(int id)
    {
        return new SuccessDataResult<Category>(_categoryDal.GetById(id));
    }
}
