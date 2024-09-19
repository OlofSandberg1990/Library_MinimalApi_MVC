using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOs;

namespace LibraryAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, CreateAndUpdateBookDTO>().ReverseMap();

        }
    }
}
