using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Coso.Abp.Theme.AdminLTE.Bundling
{
    public class AdminLTEThemeGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
 //               < script src = "/libs/abp/utils/abp-utils.umd.min.js?_v=637262917200000000" ></ script >
 //< script src = "/libs/abp/core/abp.js?_v=637262917200000000" ></ script >
 // < script src = "/libs/jquery/jquery.js?_v=637262917200000000" ></ script >
 //  < script src = "/libs/abp/jquery/abp.jquery.js?_v=637262917200000000" ></ script >

            context.Files.Add("/libs/jquery/jquery.js");
            context.Files.Add("/themes/adminlte/js/adminlte.min.js");
            context.Files.Add("/themes/adminlte/js/demo.js");
            context.Files.Add("/themes/adminlte/js/main.js");
            context.Files.Add("/themes/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
            context.Files.Add("/themes/plugins/datatables-responsive/js/dataTables.responsive.js");
            context.Files.Add("/themes/plugins/datatables-responsive/js/responsive.bootstrap4.js");
            context.Files.Add("/themes/plugins/jquery-table2excel/jquery.table2excel.js");
            context.Files.Add("/themes/plugins/datatables-select/dataTables.select.min.js");
            context.Files.Add("/themes/plugins/bootstrap-fileinput/js/fileinput.min.js");
            context.Files.Add("/themes/plugins/bootstrap-fileinput/js/plugins/purify.js");
            context.Files.Add("/themes/plugins/bootstrap-fileinput/themes/fas/theme.min.js");
            context.Files.Add("/themes/plugins/bootstrap-fileinput/js/locales/zh.js");
            context.Files.Add("/themes/plugins/daterangepicker/moment.min.js");
            context.Files.Add("/themes/plugins/daterangepicker/daterangepicker.js");
        }
    }
}
