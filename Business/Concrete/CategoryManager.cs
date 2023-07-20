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

namespace Business.Concrete;

public class CategoryManager: ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;


    public CategoryManager(ICategoryDal categoryDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;      
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


}
