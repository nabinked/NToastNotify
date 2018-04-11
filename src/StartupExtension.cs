using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NToastNotify;
using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtension
    {
        /// <summary>
        /// Add the NToastNotify middleware to handle ajax request.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNToastNotify(this IApplicationBuilder builder)
        {
            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = Utils.GetEmbeddedFileProvider(),
                RequestPath = new PathString("/ntoastnotify")
            });
            builder.UseMiddleware<NtoastNotifyAjaxToastsMiddleware>();
            return builder;
        }

        internal static IMvcBuilder AddNToastNotifyToMvcBuilder<TNotificationImplementation>(this IMvcBuilder mvcBuilder,
                                                                                                    ILibrary library,
                                                                                                    NToastNotifyOption nToastNotifyOptions)
            where TNotificationImplementation : class, IToastNotification
        {
            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcBuilder?.AddRazorOptions(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            var services = mvcBuilder.Services;
            AddNToastNotifyToServiceCollection<TNotificationImplementation>(services, library, nToastNotifyOptions);
            return mvcBuilder;
        }
        internal static IMvcCoreBuilder AddNToastNotifyToMvcBuilder<TNotificationImplementation>(this IMvcCoreBuilder mvcCoreBuilder,
                                                                                                    ILibrary library,
                                                                                                    NToastNotifyOption nToastNotifyOptions)
            where TNotificationImplementation : class, IToastNotification
        {
            if (mvcCoreBuilder == null) return null;

            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcCoreBuilder.AddRazorViewEngine(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            var services = mvcCoreBuilder.Services;
            AddNToastNotifyToServiceCollection<TNotificationImplementation>(services, library, nToastNotifyOptions);
            return mvcCoreBuilder;
        }
        internal static IServiceCollection AddNToastNotifyToServiceCollection<TNotificationImplementation>(this IServiceCollection services,
                                                                                                    ILibrary library,
                                                                                                    NToastNotifyOption nToastNotifyOptions)
            where TNotificationImplementation : class, IToastNotification
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            #region Framework Services
            //Add the file provider to the Razor view engine
            var fileProvider = Utils.GetEmbeddedFileProvider();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(fileProvider);
            });

            //Check if a TempDataProvider is already registered.
            var tempDataProvider = services.FirstOrDefault(d => d.ServiceType == typeof(ITempDataProvider));
            if (tempDataProvider == null)
            {
                //Add a tempdata provider when one is not already registered
                services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            }
            //check if IHttpContextAccessor implementation is not registered. Add one if not.
            var httpContextAccessor = services.FirstOrDefault(d => d.ServiceType == typeof(IHttpContextAccessor));
            if (httpContextAccessor == null)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }

            #endregion

            #region Custom Services
            //Add TempDataWrapper for accessing and adding values to tempdata.
            services.AddSingleton<ITempDataWrapper, TempDataWrapper>();
            // Add MessageContainerFactory for creating MessageContainer instance
            services.AddSingleton<IMessageContainerFactory, MessageContainerFactory>();

            //Add the ToastNotification implementation
            services.AddScoped<IToastNotification, TNotificationImplementation>();
            //Middleware
            services.AddScoped<NtoastNotifyAjaxToastsMiddleware>();

            //Addes instances
            services.AddSingleton(library);
            // Add the NToastifyOptions to the services container for DI retrieval 
            //(options that are not rendered as they are not part of the plugin)
            services.AddSingleton(nToastNotifyOptions);

            #endregion

            return services;
        }
    }
}
