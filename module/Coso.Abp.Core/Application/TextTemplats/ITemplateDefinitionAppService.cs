using Coso.Abp.Core.Application.TextTemplats.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Coso.Abp.Core.TextTemplats
{
    public interface ITemplateDefinitionAppService : IApplicationService
    {
        PagedResultDto<TemplateDefinitionDto> GetList(TemplateDefinitionPagedRequestDto input);

        TemplateDefinitionDto GetOrNull(string name);


    }
}
