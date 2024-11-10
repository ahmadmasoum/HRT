using AutoMapper;
using HRT.Books;

namespace HRT.Web;

public class HRTWebAutoMapperProfile : Profile
{
    public HRTWebAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        
        //Define your object mappings here, for the Web project
    }
}
