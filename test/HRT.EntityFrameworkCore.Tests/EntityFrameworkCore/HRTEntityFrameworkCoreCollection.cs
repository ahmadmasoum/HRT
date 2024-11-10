using Xunit;

namespace HRT.EntityFrameworkCore;

[CollectionDefinition(HRTTestConsts.CollectionDefinitionName)]
public class HRTEntityFrameworkCoreCollection : ICollectionFixture<HRTEntityFrameworkCoreFixture>
{

}
