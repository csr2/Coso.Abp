using Coso.Abp.Core.Definitions;
using Coso.Abp.Core.Localization;
using Coso.Abp.Core.Navigation;
using EasyAbp.Abp.SettingUi;
using EasyAbp.Abp.SettingUi.Localization;
using EasyAbp.Abp.SettingUi.Web;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Coso.Abp.Core
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
         typeof(AbpTextTemplatingModule),
         typeof(SettingUiDomainSharedModule),
         typeof(SettingUiApplicationModule),
         typeof(SettingUiWebModule) 
    )]
    public class CosoAbpCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(CosoAbpCoreResource), typeof(CosoAbpCoreModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CosoAbpCoreModule).Assembly);
            });
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CosoAbpCoreWebMainMenuContributor());
            });
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CosoAbpCoreModule>("Coso.Abp.Core");
            });
            context.Services.AddAutoMapperObjectMapper<CosoAbpCoreModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CosoAbpCoreModule>(validate: false);
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(CosoAbpCoreModule).Assembly);
                options.ConventionalControllers.Create(typeof(SettingUiApplicationModule).Assembly);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CosoAbpCoreResource>("en")
                    .AddVirtualJson("/Localization/Core");

                options.Resources
                  .Get<SettingUiResource>()
                  .AddVirtualJson("/Localization/Core");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Coso.Abp.Core", typeof(CosoAbpCoreResource));
            });

            Configure<AbpJsonOptions>(options =>
            {
                // options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                options.DefaultDateTimeFormat = "yyyy-MM-dd";
            });

        }
    }
}
