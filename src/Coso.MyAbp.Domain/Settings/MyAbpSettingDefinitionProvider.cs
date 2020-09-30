using Volo.Abp.Settings;

namespace Coso.MyAbp.Settings
{
    public class MyAbpSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MyAbpSettings.MySetting1));
        }
    }
}
