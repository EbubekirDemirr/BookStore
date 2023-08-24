using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Authentication;
using Entities.Concrete.Models;
using Entities.Concrete.Models.Authors;
using Entities.Concrete.Models.BookAndAuthor;
using Entities.Concrete.Models.BookImages;
using Entities.Concrete.Models.Books;
using Entities.Concrete.Models.Category;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;

namespace Business.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region User
        CreateMap<AppUser, LoginUser>().ReverseMap();
        CreateMap<AppUser, RegisterUser>().ReverseMap();
        #endregion

        #region Book
        CreateMap<Book, BookNavigateDto>().ReverseMap();
        CreateMap<Book, BookModel>()
            .ForMember(std => std.BookId, opt => opt.MapFrom(tgtdd => tgtdd.Id))
            .ForMember(std => std.BookName, opt => opt.MapFrom(tgtdd => tgtdd.BookName))
            .ForMember(std => std.Description, opt => opt.MapFrom(tgtdd => tgtdd.Description))
            .ForMember(std => std.PageCount, opt => opt.MapFrom(tgtdd => tgtdd.PageCount));

        CreateMap<Book, CreateBookDTO>().ReverseMap();
        CreateMap<Book, DeleteBookDTO>().ReverseMap();
        CreateMap<Book, UpdateBookDTO>().ReverseMap();
        //CreateMap<Book, BookImage>().ReverseMap();
        CreateMap<Book, GetBooksDetail>().ReverseMap();
        #endregion


        CreateMap<BookAndAuthor, GetBooksDetail>().ReverseMap();
      
        CreateMap<BookAndCategory, GetBooksDetail>().ReverseMap();


        CreateMap<BookImage, CreateBookImageDto>().ReverseMap();
        CreateMap<BookImage, BookImageNavigateDto>().ReverseMap();
        CreateMap<AuthorImage, CreateAuthorImageDto>().ReverseMap();
        CreateMap<AuthorImage, AuthorImageNavigateDto>().ReverseMap();


        #region Author
        CreateMap<Author, AuthorNavigateDto>().ReverseMap();
        CreateMap<Author, CreateAuthorDTO>().ReverseMap();
        CreateMap<Author, DeleteAuthorDTO>().ReverseMap();
        CreateMap<Author, UpdateAuthorDTO>().ReverseMap();
        CreateMap<Author, AuthorModel>()
            .ForMember(std => std.AuthorId, opt => opt.MapFrom(tgtdd => tgtdd.Id))
            .ForMember(std => std.AuthorFirstName, opt => opt.MapFrom(tgtdd => tgtdd.AuthorFirstName))
            .ForMember(std => std.AuthorLastName, opt => opt.MapFrom(tgtdd => tgtdd.AuthorLastName))
            .ForMember(std => std.Biography, opt => opt.MapFrom(tgtdd => tgtdd.Biography));
        #endregion

        #region Category

        CreateMap<Category, CategoryModel>().ReverseMap();
        CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        CreateMap<Category, DeleteCategoryDTO>().ReverseMap();
        CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        CreateMap<Category, CategoryNavigateDto>().ReverseMap();
        #endregion

        #region Publisher
        CreateMap<Publisher, PublisherModel>().ReverseMap();
        CreateMap<Publisher, CreatePublisherDTO>().ReverseMap();
        CreateMap<Publisher, DeletePublisherDTO>().ReverseMap();
        CreateMap<Publisher, UpdatePublisherDTO>().ReverseMap();
        #endregion
    }
}
