using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using HRT.Localization;

namespace HRT.Web;

[Dependency(ReplaceServices = true)]
public class HRTBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HRTResource> _localizer;

    public HRTBrandingProvider(IStringLocalizer<HRTResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
