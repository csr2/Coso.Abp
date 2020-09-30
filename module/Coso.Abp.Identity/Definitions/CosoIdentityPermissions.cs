using Volo.Abp.Reflection;

namespace Coso.Abp.Identity.Definitions
{
    public static class CosoIdentityPermissions
    {
        public const string GroupName = "AbpIdentity";

        public class IdentitySecurityLogs
        {
            public const string Default = GroupName + ".IdentitySecurityLogs";
        }

        public static class OrganizationUnits
        {
            public const string Default = GroupName + ".OrganizationUnits";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ManagePermissions = Default + ".ManagePermissions";
        }



        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CosoIdentityPermissions));
        }
    }
}
