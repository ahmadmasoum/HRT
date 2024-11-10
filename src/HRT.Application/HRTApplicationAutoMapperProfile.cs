using AutoMapper;
using HRT.Books;

namespace HRT;

public class HRTApplicationAutoMapperProfile : Profile
{
    public HRTApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
