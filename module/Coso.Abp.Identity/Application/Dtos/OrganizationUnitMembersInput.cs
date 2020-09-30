using System;
using System.Collections.Generic;
using System.Text;

namespace Coso.Abp.Identity.Application.Dtos
{
    public class OrganizationUnitMembersInput
    {
       public List<Guid> UserIds { get; set; }
       public Guid OuId { get; set; }
    }
    public class DeleteOrganizationUnitMembersInput
    {
        public Guid UserId { get; set; }
        public Guid OuId { get; set; }
    }

    public class OrganizationUnitRolesInput
    {
        public List<Guid> RoleIds { get; set; }
        public Guid OuId { get; set; }
    }

    public class DeleteOrganizationUnitRolesInput
    {
        public Guid UserId { get; set; }
        public Guid OuId { get; set; }
    }
}
