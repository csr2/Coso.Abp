using Coso.Abp.Identity.Definitions;
using Coso.Abp.Identity.Localization;
using Coso.Abp.Identity.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Coso.Abp.Identity
{
    [DependsOn(
       typeof(AbpAutoMapperModule),
      // typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule)
   )]
    public class CosoAbpIdentityModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(CosoIdentityResource), typeof(CosoAbpIdentityModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CosoAbpIdentityModule).Assembly);
            });
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CosoAbpIdentityWebMainMenuContributor());
            });
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CosoAbpIdentityModule>("Coso.Abp.Identity");
            });
            context.Services.AddAutoMapperObjectMapper<CosoAbpIdentityModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CosoAbpIdentityModule>(validate: false);
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(CosoAbpIdentityModule).Assembly);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CosoIdentityResource>("en")
                    .AddBaseTypes(
                        typeof(AbpValidationResource)
                    ).AddVirtualJson("/Localization/Identity");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Coso.Abp.Identity", typeof(CosoIdentityResource));
            });
            Configure<AbpJsonOptions>(options =>
            {
                // options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                options.DefaultDateTimeFormat = "yyyy-MM-dd";
            });

            //创建动态客户端代理
            // context.Services.AddHttpClientProxies(typeof(CosoAbpIdentityModule).Assembly);


        }
    }
}
