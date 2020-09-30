using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Coso.Abp.Theme.AdminLTE.Themes.AdminLTE.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponent : AbpViewComponent
    {
        private readonly ILanguageProvider _languageProvider;

        public LanguageSwitchViewComponent(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageProvider.GetLanguagesAsync();
            List<LanguageInfo> list = new List<LanguageInfo>();
            foreach (var entity in languages)
            {
                entity.FlagIcon = GetFlagIcon(entity.CultureName);
                if (!string.IsNullOrEmpty(entity.FlagIcon)) {
                    list.Add(entity);
                }
                

            }
            var currentLanguage = languages.FindByCulture(
                CultureInfo.CurrentCulture.Name,
                CultureInfo.CurrentUICulture.Name
            );
            currentLanguage.FlagIcon = GetFlagIcon(currentLanguage.CultureName);
            var model = new LanguageSwitchViewComponentModel
            {
                CurrentLanguage = currentLanguage,
                OtherLanguages = list.Where(l => l != currentLanguage).ToList()
            };
            return View("~/Themes/AdminLTE/Components/Toolbar/LanguageSwitch/Default.cshtml", model);
        }

        private string GetFlagIcon(string CultureName)
        {
            string FlagIcon = "";
            if (CultureName == "cs")
            {
                FlagIcon = "";
            }
            if (CultureName == "en")
            {
                FlagIcon = "gb";
            }
            if (CultureName == "pt-BR")
            {
                FlagIcon = "";
            }
            if (CultureName == "tr")
            {
                FlagIcon = "tr";
            }
            if (CultureName == "zh-Hans")
            {
                FlagIcon = "cn";
            }
            if (CultureName == "zh-Hant")
            {
                FlagIcon = "";
            }
            return FlagIcon;
        }

    }
}
