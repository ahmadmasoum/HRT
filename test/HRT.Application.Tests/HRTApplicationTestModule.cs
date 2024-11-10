using Volo.Abp.Modularity;

namespace HRT;

[DependsOn(
    typeof(HRTApplicationModule),
    typeof(HRTDomainTestModule)
)]
public class HRTApplicationTestModule : AbpModule
{

}
