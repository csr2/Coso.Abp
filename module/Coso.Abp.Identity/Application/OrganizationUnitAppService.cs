using Coso.Abp.Identity.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Coso.Abp.Identity.Application
{
     public class OrganizationUnitAppService : ApplicationService, IOrganizationUnitAppService
    {

        private readonly OrganizationUnitManager OrganizationUnitManager;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IOrganizationUnitRepository OrganizationUnitRepository;
        private readonly IBasicRepository<OrganizationUnit, Guid> _repository;

        public OrganizationUnitAppService(
        OrganizationUnitManager organizationUnitManager,
        IdentityUserManager identityUserManager,
         IOrganizationUnitRepository organizationUnitRepository,
          IBasicRepository<OrganizationUnit, Guid> repository
            )
        {
            OrganizationUnitManager = organizationUnitManager;
            _identityUserManager = identityUserManager;
            OrganizationUnitRepository = organizationUnitRepository;
            _repository = repository;
        }
        public  async Task<OrganizationUnitInput> CreateAsync(OrganizationUnitInput organizationUnit)
        {
            var id = GuidGenerator.Create();
            var input = new OrganizationUnit(id, organizationUnit.DisplayName, organizationUnit.ParentId,CurrentTenant.Id);
            organizationUnit.id = id;
            organizationUnit.Code = input.Code;
           await OrganizationUnitManager.CreateAsync(input);

            return organizationUnit;
        }
        public  async Task<UpdateOrganizationUnitInput> UpdateAsync(Guid Id, UpdateOrganizationUnitInput input)
        {

            //var entity = await OrganizationUnitRepository.GetAsync(input.DisplayName);
            var entity = await _repository.GetAsync(Id);
            entity.DisplayName = input.DisplayName;
            input.Code = entity.Code;
            input.ParentId = entity.ParentId;
            input.id = entity.Id;

            await OrganizationUnitManager.UpdateAsync(entity);

            return input;
        }
        public  async Task DeleteAsync(Guid id)
        {
            await OrganizationUnitManager.DeleteAsync(id);
        }
        public virtual async Task MoveAsync(Guid id, Guid? parentId)
        {
            await OrganizationUnitManager.MoveAsync(id, parentId);
        }

        public  async Task<List<OrganizationUnitDto>> GetChildrenAsync(Guid? parentId)
        {
            var organizationUnits = await OrganizationUnitRepository.GetChildrenAsync(parentId);

            var list = ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(organizationUnits);

            return list;
        }

        public  async Task<List<OrganizationUnitDto>> GetAllChildrenWithParentCodeAsync(string code, Guid? parentId)
        {
            var organizationUnits = await OrganizationUnitRepository.GetAllChildrenWithParentCodeAsync(code, parentId);
            var list = ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(organizationUnits);
            return list;
        }

        public async Task<OrganizationUnitDto> GetOrganizationUnitByIdAsync(Guid Id)
        {
            var organizationUnit = await _repository.GetAsync(Id);
            var entity = ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);

            return entity;
        }

        public async Task<OrganizationUnitDto> GetOrganizationUnitAsync(string displayName)
        {
            var organizationUnits = await OrganizationUnitRepository.GetAsync(displayName);

            var entity = ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnits);

            return entity;
        }

        public async Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var count = (long)await OrganizationUnitRepository.GetCountAsync();

            var list = await OrganizationUnitRepository.GetListAsync(input.Sorting, input.MaxResultCount,
               input.SkipCount);

            return new PagedResultDto<OrganizationUnitDto>(
                count,
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(list)
            );
        }

        public async Task<List<OrganizationUnitDto>> GetOrganizationUnitsAsync(IEnumerable<Guid> ids)
        {
            var organizationUnits = await OrganizationUnitRepository.GetListAsync(ids);

            var list = ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(organizationUnits);

            return list;
        }

        public async Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(PageOrganizationUnitByMembersDto input)
        {
            var organizationUnit =await _repository.GetAsync(input.OuId);
            var count = await OrganizationUnitRepository.GetMembersCountAsync(organizationUnit);
            var list= await OrganizationUnitRepository.GetMembersAsync(organizationUnit, input.Sorting,input.MaxResultCount,input.SkipCount);
            return new PagedResultDto<IdentityUserDto>(
               count,
               ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(list)
           );
        }
        public  async Task AddToOrganizationUnitAsync(OrganizationUnitMembersInput input)
        {
            if (input.UserIds.Count > 0) {
                foreach (var userid in input.UserIds) {
                    await _identityUserManager.AddToOrganizationUnitAsync(userid, input.OuId);
                }
            }
        }
        public async Task RemoveFromOrganizationUnitAsync(DeleteOrganizationUnitMembersInput input)
        {
           await _identityUserManager.RemoveFromOrganizationUnitAsync(input.UserId, input.OuId);
        }


        public async Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(PageOrganizationUnitByRolesDto input)
        {
            var organizationUnit = await _repository.GetAsync(input.OuId);
            var count = await OrganizationUnitRepository.GetRolesCountAsync(organizationUnit);
            var list = await OrganizationUnitRepository.GetRolesAsync(organizationUnit, input.Sorting, input.MaxResultCount, input.SkipCount);
            return new PagedResultDto<IdentityRoleDto>(
               count,
               ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list)
           );
        }
        public async Task AddRoleToOrganizationUnitAsync(OrganizationUnitRolesInput input)
        {
            if (input.RoleIds.Count > 0)
            {
                foreach (var roleid in input.RoleIds)
                {
                    await OrganizationUnitManager.AddRoleToOrganizationUnitAsync(roleid, input.OuId);
                }
            }
        }
        public async Task RemoveRoleFromOrganizationUnitAsync(DeleteOrganizationUnitRolesInput input)
        {
            await OrganizationUnitManager.RemoveRoleFromOrganizationUnitAsync(input.UserId, input.OuId);
        }

        //public Task<List<Dtos.IdentityRoleDto>> GetRolesAsync(OrganizationUnitDto organizationUnit, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, bool includeDetails = false, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> GetRolesCountAsync(OrganizationUnitDto organizationUnit, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}



        public virtual async Task RemoveAllMembersAsync(OrganizationUnitDto organizationUnit, CancellationToken cancellationToken = default)
        {
            var input = ObjectMapper.Map<OrganizationUnitDto, OrganizationUnit>(organizationUnit);

            await OrganizationUnitRepository.RemoveAllMembersAsync(input);
        }

        public virtual async Task RemoveAllRolesAsync(OrganizationUnitDto organizationUnit, CancellationToken cancellationToken = default)
        {
            var input = ObjectMapper.Map<OrganizationUnitDto, OrganizationUnit>(organizationUnit);

            await OrganizationUnitRepository.RemoveAllRolesAsync(input);
        }

    }
}
