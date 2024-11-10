using Volo.Abp.Modularity;

namespace HRT;

[DependsOn(
    typeof(HRTDomainModule),
    typeof(HRTTestBaseModule)
)]
public class HRTDomainTestModule : AbpModule
{

}
