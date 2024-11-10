using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HRT.Data;

/* This is used if database provider does't define
 * IHRTDbSchemaMigrator implementation.
 */
public class NullHRTDbSchemaMigrator : IHRTDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
