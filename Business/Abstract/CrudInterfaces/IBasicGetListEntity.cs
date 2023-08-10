using Core.Utilities.Results;
using Entities.Concrete.BaseEntities;

namespace Business.Abstract.CrudInterfaces;

public interface IBasicGetListEntity<TOutput>
{
    IDataResult<IEnumerable<TOutput>> GetListAsync();
}
