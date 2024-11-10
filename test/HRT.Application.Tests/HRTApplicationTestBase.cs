using Volo.Abp.Modularity;

namespace HRT;

public abstract class HRTApplicationTestBase<TStartupModule> : HRTTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
