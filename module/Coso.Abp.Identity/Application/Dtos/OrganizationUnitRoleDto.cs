using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Coso.Abp.Identity.Application.Dtos
{
    public class OrganizationUnitRoleDto : CreationAuditedEntity, IMultiTenant
    {
        /// <summary>
        /// TenantId of this entity.
        /// </summary>
        public virtual Guid? TenantId { get; protected set; }

        /// <summary>
        /// Id of the Role.
        /// </summary>
        public virtual Guid RoleId { get; protected set; }

        /// <summary>
        /// Id of the <see cref="OrganizationUnit"/>.
        /// </summary>
        public virtual Guid OrganizationUnitId { get; protected set; }
        public override object[] GetKeys()
        {
            return new object[] { OrganizationUnitId, RoleId };
        }
    }
}
