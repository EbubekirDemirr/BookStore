using AutoMapper;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete.Models.Authors;
using Entities.Concrete.Models.Books;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract;

public interface IAuthorImageService
{
    
    Core.Utilities.Results.IResult Add(IFormFile formFile, CreateAuthorImageDto authorImage);
}
