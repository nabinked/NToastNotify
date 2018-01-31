using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using Microsoft.AspNetCore.Builder;

namespace NToastNotify
{
    public static class NToastNotifyServiceCollectionExtension
    {
        public static IServiceCollection AddNToastNotify(this IServiceCollection services, ToastOption defaultOptions = null, NToastNotifyOption nToastNotifyOptions = null, IMvcBuilder mvcBuilder = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var assembly = typeof(Components.ToastrViewComponent).Assembly;
            //Create an EmbeddedFileProvider for that assembly
            var embeddedFileProvider = new EmbeddedFileProvider(assembly, "NToastNotify");
            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });

            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcBuilder?.AddRazorOptions(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });
            //Add the ToastNotification implementation
            services.AddScoped<IToastNotification, ToastNotification>();

            //Check if a TempDataProvider is already registered.
            var provider = services.BuildServiceProvider();
            var tempDataProvider = provider.GetService<ITempDataProvider>();
            if (tempDataProvider == null)
            {
                //Add a tempdata provider when one is not already registered
                services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            }

            //Add TempDataWrapper for accessing and adding values to tempdata.
            services.AddScoped<ITempDataWrapper, TempDataWrapper>();

            //check if HttpContextAccessor is not registered.
            var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
            if (httpContextAccessor == null)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }

            // Add the toastr default options that will be rendered by the viewcomponent
            defaultOptions = defaultOptions ?? ToastOption.Defaults;
            services.AddSingleton(defaultOptions);

            // Add the NToastifyOptions to the services container for DI retrieval (options that are not rendered as they are not part of the toastr.js plugin)
            nToastNotifyOptions = nToastNotifyOptions ?? NToastNotifyOption.Defaults;
            services.AddSingleton((NToastNotifyOption)nToastNotifyOptions);
            services.AddScoped<NtoastNotifyMiddleware>();
            return services;
        }

        public static IMvcBuilder AddNToastNotify(this IMvcBuilder mvcBuilder, ToastOption defaultOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
        {
            AddNToastNotify(mvcBuilder.Services, defaultOptions, nToastNotifyOptions, mvcBuilder);
            return mvcBuilder;
        }

        public static IApplicationBuilder UseNToastNotify(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NtoastNotifyMiddleware>();
        }

    }
}
