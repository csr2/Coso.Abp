using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coso.Abp.Identity.Pages.Identity.organizationunits.ViewModels
{
    public class CreateOrganizationUnitInput
    {
        public Guid? ParentId { get; set; }

        [Display(Name = "DisplayName:OrganizationUnit")]
        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Display(Name = "DisplayName:OrganizationUnit")]
        [Required]
        [StringLength(100)]
        public string NewDisplayName { get; set; }

    }
}
