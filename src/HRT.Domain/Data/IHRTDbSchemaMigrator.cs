using System.Threading.Tasks;

namespace HRT.Data;

public interface IHRTDbSchemaMigrator
{
    Task MigrateAsync();
}
