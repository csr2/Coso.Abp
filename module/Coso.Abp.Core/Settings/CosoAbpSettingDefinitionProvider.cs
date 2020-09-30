using Coso.Abp.Core.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Coso.Abp.Core.Settings
{
    public class CosoAbpSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
               new SettingDefinition(
                "Connection.Theme", // Setting name
                "Style1" // Default value
                )
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CosoAbpCoreResource>(name);
        }
    }
}