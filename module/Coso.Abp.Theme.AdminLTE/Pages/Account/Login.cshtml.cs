using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;

namespace Coso.Abp.Theme.AdminLTE.Pages.Account
{
    public class LoginModel : Volo.Abp.Account.Web.Pages.Account.LoginModel
    {
        public LoginModel(
       IAuthenticationSchemeProvider schemeProvider,
       IOptions<AbpAccountOptions> accountOptions
       ) : base(
       schemeProvider,
       accountOptions)
        {

        }

    }
}
