using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;
using Microsoft.AspNetCore.Http.Extensions;
//using Volo.Abp.Ui.Navigation;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;
using Volo.Abp.AspNetCore.Mvc;

namespace Coso.Abp.Theme.AdminLTE.Themes.AdminLTE.Components.Menu
{
    public class MainNavbarMenuViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;
        public MainNavbarMenuViewComponent(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _menuManager.GetAsync(StandardMenus.Main);
            return View("~/Themes/AdminLTE/Components/Menu/Default.cshtml", menu);
        }

        public static bool ChildActive(ApplicationMenuItemList menu, string currentName)
        {
            foreach (var item in menu)
            {
                if (item.Name == currentName)
                {
                    return true;
                }

                if (ChildActive(item.Items, currentName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
