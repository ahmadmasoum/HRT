using System;
using System.Threading.Tasks;
using HRT.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HRT.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        GetPolicyName = HRTPermissions.Books.Default;
        GetListPolicyName = HRTPermissions.Books.Default;
        CreatePolicyName = HRTPermissions.Books.Create;
        UpdatePolicyName = HRTPermissions.Books.Edit;
        DeletePolicyName = HRTPermissions.Books.Delete;
    }

    public override Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return base.GetListAsync(input);
    }
}