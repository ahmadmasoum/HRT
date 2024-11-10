using HRT.Localization;
using Volo.Abp.Application.Services;

namespace HRT;

/* Inherit your application services from this class.
 */
public abstract class HRTAppService : ApplicationService
{
    protected HRTAppService()
    {
        LocalizationResource = typeof(HRTResource);
    }
}
