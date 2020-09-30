using Coso.Abp.Identity.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Coso.Abp.Identity.Application
{
    public interface IOrganizationUnitAppService : IApplicationService
    {

        Task<OrganizationUnitInput> CreateAsync(OrganizationUnitInput organizationUnit);


        Task<UpdateOrganizationUnitInput> UpdateAsync(Guid Id, UpdateOrganizationUnitInput organizationUnit);

        Task DeleteAsync(Guid id);

        Task MoveAsync(Guid id, Guid? parentId);


        Task<List<OrganizationUnitDto>> GetChildrenAsync( Guid? parentId);

        Task<List<OrganizationUnitDto>> GetAllChildrenWithParentCodeAsync( string code, Guid? parentId);
        Task<OrganizationUnitDto> GetOrganizationUnitByIdAsync(Guid Id);
        Task<OrganizationUnitDto> GetOrganizationUnitAsync( string displayName);

        Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<List<OrganizationUnitDto>> GetOrganizationUnitsAsync(IEnumerable<Guid> ids);

        //Task<List<IdentityRoleDto>> GetRolesAsync(OrganizationUnitDto organizationUnit,string sorting = null,int maxResultCount = int.MaxValue,int skipCount = 0,bool includeDetails = false, CancellationToken cancellationToken = default );

        //Task<int> GetRolesCountAsync(OrganizationUnitDto organizationUnit, CancellationToken cancellationToken = default);

        Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(PageOrganizationUnitByMembersDto input);

        Task AddToOrganizationUnitAsync(OrganizationUnitMembersInput input);

        Task RemoveFromOrganizationUnitAsync(DeleteOrganizationUnitMembersInput input);

        Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(PageOrganizationUnitByRolesDto input);

        Task AddRoleToOrganizationUnitAsync(OrganizationUnitRolesInput input);

        Task RemoveRoleFromOrganizationUnitAsync(DeleteOrganizationUnitRolesInput input);

        Task RemoveAllRolesAsync(OrganizationUnitDto organizationUnit, CancellationToken cancellationToken = default);

        Task RemoveAllMembersAsync(OrganizationUnitDto organizationUnit, CancellationToken cancellationToken = default);
    }
}
