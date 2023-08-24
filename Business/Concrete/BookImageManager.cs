using AutoMapper;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models.Books;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class BookImageManager : IBookImageService
{
    private readonly IBookImageDal _bookImageDal;
    private readonly IFileHelper _fileHelper;
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkDal _unitOfWorkDal;

    public BookImageManager(IBookImageDal bookImageDal, IFileHelper fileHelper, IMapper mapper, IUnitOfWorkDal unitOfWorkDal)
    {
        _bookImageDal = bookImageDal;
        _fileHelper = fileHelper;
        _mapper = mapper;
        _unitOfWorkDal = unitOfWorkDal;
    }

    public Core.Utilities.Results.IResult Add(IFormFile formFile, CreateBookImageDto bookImage)
    {
        var mapped = _mapper.Map<BookImage>(bookImage);
        mapped.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
        mapped.BookId = bookImage.BookId;
        _bookImageDal.Insert(mapped);
        _unitOfWorkDal.Save();
        

        return new SuccessResult("Resim başarıyla yüklendi");
    }

    public IDataResult<List<BookImage>> GetByBookId(int bookId)
    {
        var result = _bookImageDal.GetX(x => x.BookId == bookId);
        var mapped = _mapper.Map<List<BookImage>>(result);
        return new SuccessDataResult<List<BookImage>>(mapped);
    }


    
}
