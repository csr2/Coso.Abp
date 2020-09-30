using Volo.Abp.Reflection;

namespace Coso.Abp.Core.Definitions
{
    public static class CosoAbpCorePermissions
    {
        public const string GroupName = "CosoAbpCore";

        public class Auditing
        {
            public const string Default = GroupName + ".Auditing";
        }
        public class TestTemplats
        {
            public const string Default = GroupName + ".TestTemplats";
            public const string Update = Default + ".Update";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CosoAbpCorePermissions));
        }
    }
}
