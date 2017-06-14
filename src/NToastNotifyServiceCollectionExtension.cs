using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;

namespace NToastNotify
{
    public static class NToastNotifyServiceCollectionExtension
    {
        public static IServiceCollection AddNToastNotify(this IServiceCollection services, ToastOption defaultOptions = null, NToastNotifyOptions nToastNotifyOptions = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            var assembly = typeof(Components.ToastrViewComponent).GetTypeInfo().Assembly;
            //Create an EmbeddedFileProvider for that assembly
            var embeddedFileProvider = new EmbeddedFileProvider(assembly, "NToastNotify");
            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });
            services.AddScoped<IToastNotification, ToastNotification>();
            //Check if a TempDataProvider is already registered.
            var provider = services.BuildServiceProvider();
            var tempDataProvider = provider.GetService<ITempDataProvider>();
            if (tempDataProvider == null)
            {
                services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            }
            //check if HttpContextAccessor is not registered.
            var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
            if (httpContextAccessor == null)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }

            // Add the toastr default options that will be rendered by the viewcomponent
            var defaults = defaultOptions ?? ToastOption.Defaults;
            services.AddSingleton(defaults);

            // Add the NToastifyOptions to the services container for DI retrieval (options that are not rendered as they are not part of the Toastr.js plugin)
            var defaultNToastNotifyOptions = nToastNotifyOptions ?? NToastNotifyOptions.Defaults;
            services.AddSingleton(defaultNToastNotifyOptions);     
            return services;
        }
    }
}
