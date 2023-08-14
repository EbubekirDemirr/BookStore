using AutoMapper;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Models.Books;
using Entities.Concrete.Models.GetBookDetail;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class BookImageManager : IBookImageService
{
    private readonly IBookImageDal _bookImageDal;
    private readonly IFileHelper _fileHelper;
    private readonly IMapper _mapper;

    public BookImageManager(IBookImageDal bookImageDal, IFileHelper fileHelper, IMapper mapper)
    {
        _bookImageDal = bookImageDal;
        _fileHelper = fileHelper;
        _mapper = mapper;
    }

    public Core.Utilities.Results.IResult Add(IFormFile formFile, CreateBookImageDto bookImage)
    {
        var mapped = _mapper.Map<BookImage>(bookImage);
        mapped.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
        mapped.BookId = bookImage.BookId;
        _bookImageDal.Insert(mapped);

        return new SuccessResult("Resim başarıyla yüklendi");
    }

    public IDataResult<List<BookImage>> GetAll()
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<BookImage>> GetByBookId(int bookId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<BookImage> GetByImageId(int imageId)
    {
        throw new NotImplementedException();
    }

    
}
