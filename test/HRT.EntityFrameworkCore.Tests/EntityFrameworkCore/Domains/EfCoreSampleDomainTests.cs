using HRT.Samples;
using Xunit;

namespace HRT.EntityFrameworkCore.Domains;

[Collection(HRTTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<HRTEntityFrameworkCoreTestModule>
{

}
