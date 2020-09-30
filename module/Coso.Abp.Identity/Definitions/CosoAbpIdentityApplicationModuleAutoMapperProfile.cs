using AutoMapper;
using Coso.Abp.Identity.Application.Dtos;
using Coso.Abp.Identity.Pages.Identity.organizationunits.ViewModels;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;

namespace Coso.Abp.Identity.Definitions
{
    public class CosoAbpIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public CosoAbpIdentityApplicationModuleAutoMapperProfile()
        {
            CreateMap<IdentitySecurityLog, IdentitySecurityLogDto>();

            CreateMap<OrganizationUnit, OrganizationUnitDto>();
            CreateMap<OrganizationUnit, OrganizationUnitInput>();

            CreateMap<OrganizationUnitDto, CreateOrganizationUnitInput>();
            CreateMap<CreateOrganizationUnitInput, UpdateOrganizationUnitInput>();
            CreateMap<CreateOrganizationUnitInput, OrganizationUnitInput>();

        }
    }
}
