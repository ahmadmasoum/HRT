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

        var candidatesPermission = myGroup.AddPermission(HRTPermissions.Candidates.Default, L("Permission:Candidates"));
        candidatesPermission.AddChild(HRTPermissions.Candidates.Create, L("Permission:Candidates.Create"));
        candidatesPermission.AddChild(HRTPermissions.Candidates.Edit, L("Permission:Candidates.Edit"));
        candidatesPermission.AddChild(HRTPermissions.Candidates.Delete, L("Permission:Candidates.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(HRTPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HRTResource>(name);
    }
}
