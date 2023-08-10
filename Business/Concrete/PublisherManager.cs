using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Redis;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;

namespace Business.Concrete;

public class PublisherManager: IPublisherService
{
    private readonly IPublisherDal _publisherDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;
    private readonly LibraryContext _libraryContext;

    public PublisherManager(IPublisherDal publisherDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper, ICacheService cacheService, LibraryContext libraryContext)
    {
        _publisherDal = publisherDal;
        _unitOfWorkDal = unitOfWorkDal;
        _mapper = mapper;
        _cacheService = cacheService;
        _libraryContext = libraryContext;
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

    public IDataResult<List<PublisherModel>> Get()
    {
        var cacheData = _cacheService.GetData<List<PublisherModel>>("GetCategory");
        if (cacheData != null)
        {
            return new SuccessDataResult<List<PublisherModel>>(cacheData);
        }
        var expirationTime = DateTimeOffset.Now.AddDays(5);
        var publishers = _libraryContext.Publishers.ToList();
        var publisherModels = _mapper.Map<List<PublisherModel>>(publishers);
        _cacheService.SetData("GetCategory", publisherModels, expirationTime);

        return new SuccessDataResult<List<PublisherModel>>(publisherModels);
    }
}
