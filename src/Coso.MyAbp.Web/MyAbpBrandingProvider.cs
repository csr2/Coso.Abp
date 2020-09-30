using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Coso.MyAbp.Web
{
    [Dependency(ReplaceServices = true)]
    public class MyAbpBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MyAbp";
    }
}
