using Volo.Abp.Modularity;

namespace HRT;

/* Inherit from this class for your domain layer tests. */
public abstract class HRTDomainTestBase<TStartupModule> : HRTTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
