using HRT.Books;
using Xunit;

namespace HRT.EntityFrameworkCore.Applications.Books;

[Collection(HRTTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<HRTEntityFrameworkCoreTestModule>
{

}