using Business.Abstract.CrudInterfaces;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Entities.Concrete;
using Entities.Concrete.Models;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface ICategoryService: IBasicCreateEntity<CreateCategoryDTO>,
    IBasicDeleteEntity<DeleteCategoryDTO>,
    IBasicUpdateEntity<UpdateCategoryDTO>,
    IBasicGetByIdEntity<Category, int>
{
    IDataResult<List<CategoryModel>> Get();
   
}
