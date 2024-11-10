using HRT.Samples;
using Xunit;

namespace HRT.EntityFrameworkCore.Applications;

[Collection(HRTTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<HRTEntityFrameworkCoreTestModule>
{

}
