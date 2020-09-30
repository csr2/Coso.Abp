using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Coso.Abp.Theme.AdminLTE.Bundling
{
    public class AdminLTEThemeGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
         
            context.Files.Add("/themes/adminlte/css/adminlte.min.css");
            context.Files.Add("/themes/plugins/overlayScrollbars/css/OverlayScrollbars.min.css");
            context.Files.Add("/themes/plugins/flag-icon-css/css/flag-icon.css");
            context.Files.Add("/themes/plugins/datatables-responsive/css/responsive.bootstrap4.css");
            context.Files.Add("/themes/adminlte/css/style.css");
            context.Files.Add("/themes/plugins/bootstrap-fileinput/css/fileinput.css");
            context.Files.Add("/themes/plugins/daterangepicker/daterangepicker.css");
            // context.Files.Add("/themes/adminlte/layout.css");
        }
    }
}
