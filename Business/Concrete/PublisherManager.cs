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

public class PublisherManager: IPublisherService
{
    private readonly IPublisherDal _publisherDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;

    public PublisherManager(IPublisherDal publisherDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper)
    {
        _publisherDal = publisherDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
    }

    public IResult CreateEntity(CreatePublisherDTO tEntity)
    {
        var mappedPublisher = _mapper.Map<Publisher>(tEntity);
        _publisherDal.Insert(mappedPublisher);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Created);
    }

    public IResult DeleteEntity(DeletePublisherDTO tEntity)
    {
        var mappedPublisher = _mapper.Map<Publisher>(tEntity);
        _publisherDal.Delete(mappedPublisher);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Deleted);
    }

    public IDataResult<Publisher> GetByIdEntity(int id)
    {
        return new SuccessDataResult<Publisher>(_publisherDal.GetById(id));
    }

    public IResult UpdateEntity(UpdatePublisherDTO tEntity)
    {
        var mappedPublisher = _mapper.Map<Publisher>(tEntity);
        _publisherDal.Update(mappedPublisher);
        _unitOfWorkDal.Save();
        return new SuccessResult(Messages.Updated);
    }
}
