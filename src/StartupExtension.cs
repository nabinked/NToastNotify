using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NToastNotify;
using NToastNotify.Helpers;
using NToastNotify.Libraries;
using NToastNotify.MessageContainers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtension
    {
        private const string NToastNotifyCorsPolicy = nameof(NToastNotifyCorsPolicy);

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
            builder.UseMiddleware<NtoastNotifyMiddleware>();
            return builder;
        }

        internal static IMvcBuilder AddNToastNotifyToMvcBuilder<TLibrary, TOption, TNotificationImplementation>(this IMvcBuilder mvcBuilder,
                                                                                                                            TOption defaultLibOptions,
                                                                                                                            NToastNotifyOption nToastNotifyOptions = null)
            where TLibrary : class, ILibrary<TOption>, new()
            where TOption : class, ILibraryOptions
            where TNotificationImplementation : class, IToastNotification
        {
            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcBuilder?.AddRazorOptions(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            var services = mvcBuilder.Services;
            AddNToastNotifyToServiceCollection<TLibrary, TOption, TNotificationImplementation>(services, defaultLibOptions, nToastNotifyOptions);
            return mvcBuilder;
        }
        internal static IMvcCoreBuilder AddNToastNotifyToMvcBuilder<TLibrary, TOption, TNotificationImplementation>(this IMvcCoreBuilder mvcCoreBuilder,
                                                                                                                            TOption defaultLibOptions,
                                                                                                                            NToastNotifyOption nToastNotifyOptions = null)
            where TLibrary : class, ILibrary<TOption>, new()
            where TOption : class, ILibraryOptions
            where TNotificationImplementation : class, IToastNotification
        {
            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcCoreBuilder?.AddRazorViewEngine(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            var services = mvcCoreBuilder.Services;
            AddNToastNotifyToServiceCollection<TLibrary, TOption, TNotificationImplementation>(services, defaultLibOptions, nToastNotifyOptions);
            return mvcCoreBuilder;
        }
        internal static IServiceCollection AddNToastNotifyToServiceCollection<TLibrary, TOption, TNotificationImplementation>(this IServiceCollection services, TOption defaultLibOptions,
            NToastNotifyOption nToastNotifyOptions = null)
            where TLibrary : class, ILibrary<TOption>, new()
            where TOption : class, ILibraryOptions
            where TNotificationImplementation : class, IToastNotification
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


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

            //Add TempDataWrapper for accessing and adding values to tempdata.
            services.AddSingleton<ITempDataWrapper, TempDataWrapper>();

            //check if IHttpContextAccessor implementation is not registered. Add one if not.
            var httpContextAccessor = services.FirstOrDefault(d => d.ServiceType == typeof(IHttpContextAccessor));
            if (httpContextAccessor == null)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }

            var library = new TLibrary();

            // Add the toast library default options that will be rendered by the viewcomponent
            services.AddSingleton<ILibraryOptions>(defaultLibOptions ?? library.Defaults);

            // Add the NToastifyOptions to the services container for DI retrieval 
            //(options that are not rendered as they are not part of the plugin)
            nToastNotifyOptions = nToastNotifyOptions ?? new NToastNotifyOption();
            nToastNotifyOptions.LibraryDetails = library;
            services.AddSingleton(nToastNotifyOptions);
            services.AddSingleton<IMessageContainerFactory, MessageContainerFactory>();
            //Add the ToastNotification implementation
            services.AddScoped<IToastNotification, TNotificationImplementation>();
            services.AddScoped<NtoastNotifyMiddleware>();
            return services;
        }
    }
}
