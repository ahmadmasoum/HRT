using System.Threading.Tasks;
using HRT.Localization;
using HRT.Permissions;
using HRT.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace HRT.Web.Menus;

public class HRTMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<HRTResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                HRTMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                HRTMenus.Candidate,
                l["Menu:Candidates"],
                "/Candidates",
                icon: "fa fa-home",
                order: 2
            ).RequirePermissions(HRTPermissions.Candidates.Default)
        );


        context.Menu.AddItem(
             new ApplicationMenuItem(
                "Apply",
                l["Menu:Apply"],
                icon: "fa fa-book",
                order: 2,
                url: "/Candidates/Create")
             );



        //Administration
        //var administration = context.Menu.TryRemoveMenuItem(DefaultMenuNames.Application.Main.Administration);

        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
        administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);

        //if (MultiTenancyConsts.IsEnabled)
        //{
        //    administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        //}
        //else
        //{
        //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //}

        //administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        administration.TryRemoveMenuItem(SettingManagementMenuNames.GroupName);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);

        return Task.CompletedTask;
    }
}
