using Coso.Abp.Core;
using Coso.Abp.Core.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Coso.Abp.Core.Pages
{
    public abstract class CosoAbpCorePageModel : AbpPageModel
    {
        protected CosoAbpCorePageModel()
        {
            ObjectMapperContext = typeof(CosoAbpCoreModule);
            LocalizationResourceType = typeof(CosoAbpCoreResource);
         
        }
    }
}
