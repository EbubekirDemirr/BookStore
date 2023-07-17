using Business.Abstract.CrudInterfaces;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Entities.Concrete;

namespace Business.Abstract;

public interface IAuthorService: IBasicCreateEntity<CreateAuthorDTO>,
    IBasicDeleteEntity<DeleteAuthorDTO>,
    IBasicUpdateEntity<UpdateAuthorDTO>,
    IBasicGetByIdEntity<Author, int>
{
}
