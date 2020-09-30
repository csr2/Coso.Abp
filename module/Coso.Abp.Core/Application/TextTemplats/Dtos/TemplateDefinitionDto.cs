using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Localization;

namespace Coso.Abp.Core.Application.TextTemplats.Dtos
{
    public class TemplateDefinitionDto
    {
        public string Name { get; set; }

        public bool IsLayout { get; set; }

        public string Layout { get; set; }

        public Type LocalizationResource { get; set; }

        public bool IsInlineLocalized { get; set; }

        public string DefaultCultureName { get; set; }

        public ILocalizableString DisplayName { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
