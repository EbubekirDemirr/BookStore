using Core.Utilities.Results;

namespace Business.Abstract.CrudInterfaces;

public interface IBasicUpdateEntity<TInput>
{
    IResult UpdateEntity(TInput tEntity);
}
