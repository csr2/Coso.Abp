using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Coso.Abp.Theme.AdminLTE.Themes.AdminLTE.Components.BreadCrumb
{
    public class BreadCrumbViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLTE/Components/BreadCrumb/Default.cshtml");
        }
    }
}
