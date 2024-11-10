using HRT.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HRT.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HRTEntityFrameworkCoreModule),
    typeof(HRTApplicationContractsModule)
)]
public class HRTDbMigratorModule : AbpModule
{
}
