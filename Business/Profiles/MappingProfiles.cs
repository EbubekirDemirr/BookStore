using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Authentication;
using Entities.Concrete.Models;
using Entities.Concrete.Models.Authors;
using Entities.Concrete.Models.BookAndAuthor;
using Entities.Concrete.Models.Books;
using Entities.Concrete.Models.Category;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.GetModels;
using Entities.Concrete.Models.UpdateModels;

namespace Business.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        #region User
        CreateMap<AppUser, LoginUser>().ReverseMap();
        CreateMap<AppUser, RegisterUser>().ReverseMap();
        #endregion

        #region Book
        CreateMap<Book, BookNavigateDto>().ReverseMap();             
        CreateMap<Book, GetBookDto>().ReverseMap();
        CreateMap<Book, BookModel>().ReverseMap();
        CreateMap<Book, CreateBookDTO>().ReverseMap();
        CreateMap<Book, DeleteBookDTO>().ReverseMap();
        CreateMap<Book, UpdateBookDTO>().ReverseMap();
        #endregion

        CreateMap<BookAndAuthor, GetBooksDetail>().ReverseMap();
        CreateMap<BookAndCategory, GetBooksDetail>().ReverseMap();
        


        #region Author
        CreateMap<Author, AuthorNavigateDto>().ReverseMap();
        CreateMap<Author, AuthorModel>().ReverseMap();
        CreateMap<Author, CreateAuthorDTO>().ReverseMap();
        CreateMap<Author, DeleteAuthorDTO>().ReverseMap();
        CreateMap<Author, UpdateAuthorDTO>().ReverseMap();
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
