using HRT.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HRT.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HRTController : AbpControllerBase
{
    protected HRTController()
    {
        LocalizationResource = typeof(HRTResource);
    }
}
