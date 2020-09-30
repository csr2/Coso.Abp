using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Coso.Abp.Theme.AdminLTE.Themes.AdminLTE.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponentModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public List<LanguageInfo> OtherLanguages { get; set; }
    }
}
