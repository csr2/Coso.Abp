using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Coso.Abp.Core.Application.TextTemplats.Dtos
{
    public class TemplateDefinitionPagedRequestDto : PagedAndSortedResultRequestDto
    {
        public string filterText { get; set; }
    }
}
