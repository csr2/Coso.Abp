using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Coso.Abp.Theme.AdminLTE.Bundling;
using Coso.Abp.Theme.AdminLTE.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Coso.Abp.Theme.AdminLTE.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Validation.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coso.Abp.Theme.AdminLTE
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
        )]
    public class CosoAbpThemeAdminLTEModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CosoAbpThemeAdminLTEModule).Assembly);
            });
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<AdminLTETheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = AdminLTETheme.Name;
                }
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CosoAbpThemeAdminLTEModule>("Coso.Abp.Theme.AdminLTE");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AdminLTEResource>("en")
                    .AddVirtualJson("/Localization/AdminLTE");
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AdminLTEThemeMainTopToolbarContributor());
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/index");
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(AdminLTEThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                           .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(typeof(AdminLTEThemeGlobalStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(AdminLTEThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(AdminLTEThemeGlobalScriptContributor));
                    });

            });
        }
    }
}
