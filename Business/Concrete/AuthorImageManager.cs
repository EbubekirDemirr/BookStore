using AutoMapper;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models.Authors;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class AuthorImageManager : IAuthorImageService
{
    private readonly IAuthorImageDal _authorImageDal;
    private readonly IFileHelper _fileHelper;
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkDal _unitOfWorkDal;

    public AuthorImageManager(IAuthorImageDal authorImageDal, IFileHelper fileHelper, IMapper mapper, IUnitOfWorkDal unitOfWorkDal)
    {
        _authorImageDal = authorImageDal;
        _fileHelper = fileHelper;
        _mapper = mapper;
        _unitOfWorkDal = unitOfWorkDal;
    }
    public Core.Utilities.Results.IResult Add(IFormFile formFile, CreateAuthorImageDto authorImage)
    {
        var mapped = _mapper.Map<AuthorImage>(authorImage);
        mapped.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
        mapped.AuthorId = authorImage.AuthorId;
        _authorImageDal.Insert(mapped);
        _unitOfWorkDal.Save();


        return new SuccessResult("Resim başarıyla yüklendi");
    }

    
}
