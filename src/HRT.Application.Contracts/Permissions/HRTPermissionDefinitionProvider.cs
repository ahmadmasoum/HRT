using HRT.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace HRT.Permissions;

public class HRTPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HRTPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(HRTPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(HRTPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(HRTPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(HRTPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HRTPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HRTResource>(name);
    }
}
