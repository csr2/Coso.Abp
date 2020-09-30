using Coso.Abp.Identity.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Coso.Abp.Identity.Pages.Identity
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
    * @inherits ProjectReport.Web.Pages.ProjectReportPage
    */
    public abstract class CosoIdentityPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<CosoIdentityResource> L { get; set; }

    }
}
