using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc;

namespace Coso.Abp.Theme.AdminLTE.Themes.AdminLTE.Components.Toolbar
{
    public class MainNavbarToolbarViewComponent : AbpViewComponent
    {
        private readonly IToolbarManager _toolbarManager;

        public MainNavbarToolbarViewComponent(IToolbarManager toolbarManager)
        {
            _toolbarManager = toolbarManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var toolbar = await _toolbarManager.GetAsync(StandardToolbars.Main);
            return View("~/Themes/AdminLTE/Components/Toolbar/Default.cshtml", toolbar);
        }
    }
}
