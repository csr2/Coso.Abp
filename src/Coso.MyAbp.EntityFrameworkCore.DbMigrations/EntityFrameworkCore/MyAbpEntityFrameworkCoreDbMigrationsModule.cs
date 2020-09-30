using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Coso.MyAbp.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyAbpEntityFrameworkCoreModule)
        )]
    public class MyAbpEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyAbpMigrationsDbContext>();
        }
    }
}
