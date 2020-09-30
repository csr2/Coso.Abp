using AutoMapper;
using Coso.Abp.Core.Application.TextTemplats.Dtos;
using Coso.Abp.Core.Auditing.Dtos;
using Volo.Abp.AuditLogging;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.TextTemplating;

namespace Coso.Abp.Core.Definitions
{
    public class CosoAbpCoreApplicationModuleAutoMapperProfile : Profile
    {
        public CosoAbpCoreApplicationModuleAutoMapperProfile()
        {
            CreateMap<AuditLog, AuditLogDto>();
            CreateMap<AuditLogAction, AuditLogActionDto>();
            CreateMap<EntityChange, EntityChangeDto>();
            CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            CreateMap<TemplateDefinition, TemplateDefinitionDto>();
            
        }
    }
}
