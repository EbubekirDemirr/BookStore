using Core.Utilities.Results;

namespace Business.Abstract.CrudInterfaces;

public interface IBasicGetByIdEntity<TResponse, TInput>
{
     IDataResult <TResponse> GetByIdEntity(TInput id);
}
