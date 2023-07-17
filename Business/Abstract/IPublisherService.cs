using Business.Abstract.CrudInterfaces;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using Entities.Concrete;

namespace Business.Abstract;

public interface IPublisherService: IBasicCreateEntity<CreatePublisherDTO>,
    IBasicDeleteEntity<DeletePublisherDTO>,
    IBasicUpdateEntity<UpdatePublisherDTO>,
    IBasicGetByIdEntity<Publisher, int>
{
}
