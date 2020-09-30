using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Coso.Abp.Identity.Application.Dtos
{
   public class PageOrganizationUnitByMembersDto : PagedAndSortedResultRequestDto
    {
        public Guid OuId { get; set; }
        //public string Filter { get; set; }
    }
    public class PageOrganizationUnitByRolesDto : PagedAndSortedResultRequestDto
    {
        public Guid OuId { get; set; }
        //public string Filter { get; set; }
    }
}
