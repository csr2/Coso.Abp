using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coso.Abp.Identity.Pages.Identity.organizationunits
{
    public class AddUserModal : CosoIdentityPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid OuId { get; set; }
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await Task.CompletedTask;
            return NoContent();
        }
    }
}