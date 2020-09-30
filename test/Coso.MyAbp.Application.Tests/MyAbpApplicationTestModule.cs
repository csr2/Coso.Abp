using Volo.Abp.Modularity;

namespace Coso.MyAbp
{
    [DependsOn(
        typeof(MyAbpApplicationModule),
        typeof(MyAbpDomainTestModule)
        )]
    public class MyAbpApplicationTestModule : AbpModule
    {

    }
}