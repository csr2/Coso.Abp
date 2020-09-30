using System.Threading.Tasks;
using Coso.Abp.Core.Definitions;
using Coso.Abp.Core.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.Identity.Localization;
using Volo.Abp.UI.Navigation;

namespace Coso.Abp.Core.Navigation
{
    public class CosoAbpCoreWebMainMenuContributor : IMenuContributor
    {
        public virtual async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<CosoAbpCoreResource>>();
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }
            var administration = context.Menu.GetAdministration();
            if (await authorizationService.IsGrantedAsync(CosoAbpCorePermissions.Auditing.Default))
            {
                var CosoAuditingMenuItem = new ApplicationMenuItem("CosoAuditing", l["Menu:Auditing"], "~/auditing/index", "fa fa-copy", 1002);
                administration.AddItem(CosoAuditingMenuItem);
            }
            if (await authorizationService.IsGrantedAsync(CosoAbpCorePermissions.TestTemplats.Default))
            {
                var CosoTextTemplatsMenuItem = new ApplicationMenuItem("CosoTextTemplats", l["Menu:TextTemplats"], "~/texttemplats/index", "fa fa-copy", 1002);
                administration.AddItem(CosoTextTemplatsMenuItem);
            }
        }
    }
}
