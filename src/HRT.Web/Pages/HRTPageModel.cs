using HRT.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HRT.Web.Pages;

public abstract class HRTPageModel : AbpPageModel
{
    protected HRTPageModel()
    {
        LocalizationResourceType = typeof(HRTResource);
    }
}
