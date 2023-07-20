using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Authentication;
using Entities.Concrete.Models;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;

namespace Business.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {

        CreateMap<AppUser, RegisterUser>().ReverseMap();
        CreateMap<AppUser, LoginUser>().ReverseMap();

        CreateMap<Book, CreateBookDTO > ().ReverseMap();
        CreateMap<Book, DeleteBookDTO> () .ReverseMap();
        CreateMap<Book, UpdateBookDTO> () .ReverseMap();

        CreateMap<Author, CreateAuthorDTO> ().ReverseMap();
        CreateMap<Author, DeleteAuthorDTO> () .ReverseMap();
        CreateMap<Author, UpdateAuthorDTO> () .ReverseMap ();

        CreateMap<Category, CreateCategoryDTO> ().ReverseMap();
        CreateMap<Category, DeleteCategoryDTO> () .ReverseMap();
        CreateMap<Category, UpdateCategoryDTO> () .ReverseMap();

        CreateMap<Publisher, CreatePublisherDTO> ().ReverseMap();
        CreateMap<Publisher, DeletePublisherDTO> () .ReverseMap();
        CreateMap<Publisher, UpdatePublisherDTO> ().ReverseMap ();
    }
}
