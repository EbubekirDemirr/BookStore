using Core.Utilities.Results;

namespace Business.Abstract.CrudInterfaces;

public interface IBasicDeleteEntity<TInput>
{
    IResult DeleteEntity(TInput tEntity);
}
