using System.Threading.Tasks;
using Coso.Abp.Identity.Definitions;
using Coso.Abp.Identity.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.Identity.Localization;
using Volo.Abp.UI.Navigation;

namespace Coso.Abp.Identity.Navigation
{
    public class CosoAbpIdentityWebMainMenuContributor : IMenuContributor
    {
        public virtual async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<CosoIdentityResource>>();
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            if (context.Menu.Name == StandardMenus.User)
            {
                context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", l["MyIdentitySecurityLogs"], url: "~/account/securitylogs", icon: "fa fa-cog", order: 1001, null));
            }
            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }

            var administration = context.Menu.GetAdministration();
            var indentity = administration.GetMenuItemOrNull(IdentityMenuNames.GroupName);
            if (indentity != null)
            {
                if (await authorizationService.IsGrantedAsync(CosoIdentityPermissions.OrganizationUnits.Default))
                {
                    var OrganizationUnitsMenuItem = new ApplicationMenuItem("OrganizationUnits", l["OrganizationUnits"], "~/Identity/organizationunits", "fa fa-copy", 1000);
                    indentity.AddItem(OrganizationUnitsMenuItem);
                }
                if (await authorizationService.IsGrantedAsync(CosoIdentityPermissions.IdentitySecurityLogs.Default))
                {
                    var IdentitySecurityLogsMenuItem = new ApplicationMenuItem("IdentitySecurityLogs", l["IdentitySecurityLogs"], "~/Identity/securitylogs", "fa fa-copy", 1001);
                    indentity.AddItem(IdentitySecurityLogsMenuItem);
                }
            }

        }
    }
}
