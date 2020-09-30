using System;
using System.Collections.Generic;
using System.Text;

namespace Coso.Abp.Identity.Application.Dtos
{
    public class OrganizationUnitInput
    {
        public Guid? id { get; set; }
        public Guid? ParentId { get; set; }
        public  string Code { get;  set; }
        public string DisplayName { get; set; }
    }
}
