using Business.Abstract.CrudInterfaces;
using Entities.Concrete;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;

namespace Business.Abstract;

public interface IBookService : IBasicCreateEntity<CreateBookDTO>, 
    IBasicDeleteEntity<DeleteBookDTO>,
    IBasicUpdateEntity<UpdateBookDTO>,
    IBasicGetByIdEntity<Book , int>

{

}
