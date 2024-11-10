using Volo.Abp.Settings;

namespace HRT.Settings;

public class HRTSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HRTSettings.MySetting1));
    }
}
