using Core.Utilities.Results;

namespace Business.Abstract.CrudInterfaces;

public interface IBasicCreateEntity<TInput>
{
    IResult CreateEntity(TInput tEntity);
}
