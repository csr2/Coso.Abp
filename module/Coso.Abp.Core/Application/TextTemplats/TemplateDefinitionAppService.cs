using Coso.Abp.Core.Application.TextTemplats.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.TextTemplating;

namespace Coso.Abp.Core.TextTemplats
{
    public class TemplateDefinitionAppService : ApplicationService, ITemplateDefinitionAppService
    {

        private readonly TemplateDefinitionManager _templateDefinitionManager;
        public TemplateDefinitionAppService(TemplateDefinitionManager templateDefinitionManager)
        {
            _templateDefinitionManager = templateDefinitionManager;
        }

        public PagedResultDto<TemplateDefinitionDto> GetList(TemplateDefinitionPagedRequestDto input)
        {
            var list = _templateDefinitionManager.GetAll().WhereIf(!input.filterText.IsNullOrWhiteSpace(), item => item.Name.Contains(input.filterText));

            var count = list.Count();
            var pageList = list.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<TemplateDefinitionDto>(
               count,
              ObjectMapper.Map<List<TemplateDefinition>, List<TemplateDefinitionDto>>(pageList)
           );
        }

        public TemplateDefinitionDto GetOrNull(string name)
        {
            var entity = _templateDefinitionManager.GetOrNull(name);

            return ObjectMapper.Map<TemplateDefinition,TemplateDefinitionDto>(entity);
        }

    
    }
}
