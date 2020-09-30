using Coso.MyAbp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Coso.MyAbp
{
    [DependsOn(
        typeof(MyAbpEntityFrameworkCoreTestModule)
        )]
    public class MyAbpDomainTestModule : AbpModule
    {

    }
}