using Coso.Abp.Identity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Coso.Abp.Identity.Pages.Identity
{
    public abstract class CosoIdentityPageModel : AbpPageModel
    {
        protected CosoIdentityPageModel()
        {
            ObjectMapperContext = typeof(CosoAbpIdentityModule);
            LocalizationResourceType = typeof(CosoIdentityResource);
         
        }
    }
}
