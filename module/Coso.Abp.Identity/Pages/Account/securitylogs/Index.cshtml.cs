using Coso.Abp.Identity.Pages.Identity;
using System.Threading.Tasks;

namespace Coso.Abp.Identity.Pages.Account.securitylogs
{
    public class IndexModel : CosoIdentityPageModel
    {
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
