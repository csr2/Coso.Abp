using Coso.Abp.Identity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;

namespace Coso.Abp.Identity.Definitions
{
    public class CosoIdentityPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {

            var identityGroup = context.GetGroup(IdentityPermissions.GroupName);
            identityGroup.AddPermission(CosoIdentityPermissions.IdentitySecurityLogs.Default, L("IdentitySecurityLogs"));

            var OrganizationUnits = identityGroup.AddPermission(CosoIdentityPermissions.OrganizationUnits.Default, L("OrganizationUnits"));
            OrganizationUnits.AddChild(CosoIdentityPermissions.OrganizationUnits.Update, L("Edit"));
            OrganizationUnits.AddChild(CosoIdentityPermissions.OrganizationUnits.Delete, L("Delete"));
            OrganizationUnits.AddChild(CosoIdentityPermissions.OrganizationUnits.Create, L("Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CosoIdentityResource>(name);
        }
    }
}
