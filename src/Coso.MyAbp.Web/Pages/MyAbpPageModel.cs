using Coso.MyAbp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Coso.MyAbp.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MyAbpPageModel : AbpPageModel
    {
        protected MyAbpPageModel()
        {
            LocalizationResourceType = typeof(MyAbpResource);
        }
    }
}