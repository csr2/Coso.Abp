using System.Threading.Tasks;

namespace Coso.MyAbp.Data
{
    public interface IMyAbpDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
