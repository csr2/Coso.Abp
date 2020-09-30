using Coso.Abp.Core.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;

namespace Coso.Abp.Core.Definitions
{
    public class CosoAbpCorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {

            var myGroup = context.AddGroup(CosoAbpCorePermissions.GroupName,L("Permission:CosoAbpCore"));
            myGroup.AddPermission(CosoAbpCorePermissions.Auditing.Default, L("Auditing"));

            var TestTemplats = myGroup.AddPermission(CosoAbpCorePermissions.TestTemplats.Default, L("TextTemplats"));
            TestTemplats.AddChild(CosoAbpCorePermissions.TestTemplats.Update, L("Edit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CosoAbpCoreResource>(name);
        }
    }
}
