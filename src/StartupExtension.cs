using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.FileProviders;
using NToastNotify;
using NToastNotify.Components;
using NToastNotify.Libraries;
using NToastNotify.MessageContainers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtension
    {
        private static EmbeddedFileProvider _embeddedFileProvider;
        private const string NToastNotifyCorsPolicy = nameof(NToastNotifyCorsPolicy);
        private static readonly Assembly ThisAssembly = typeof(ToastViewComponent).Assembly;
        private static EmbeddedFileProvider GetEmbeddedFileProvider()
        {
            return _embeddedFileProvider ??
          (_embeddedFileProvider = new EmbeddedFileProvider(ThisAssembly, "NToastNotify"));
        }
        [Obsolete("Please use the extension method to IMVCBuilder. For e.g. services.AddMvc().AddNToastNotify()", true)]
        public static IServiceCollection AddNToastNotify(this IServiceCollection services, ToastrOptions defaultOptions = null, NToastNotifyOption nToastNotifyOptions = null, IMvcBuilder mvcBuilder = null)
        {
            return services;
        }
        /// <summary>
        /// Addes the necessary services for NToastNotify. Default <see cref="ILibrary{TOption}" used is <see cref="Toastr"/>/>
        /// </summary>
        /// <typeparam name="TLibrary">Toastr</typeparam>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        [Obsolete("Please use the library specific method either AddNToastNotifyToastr or AddNToastNotifyNoty")]
        public static IMvcBuilder AddNToastNotify(this IMvcBuilder mvcBuilder, ToastrOptions defaultOptions = null, NToastNotifyOption nToastNotifyOptions = null)
        {
            return AddNToastNotifyToMvcBuilder<ToastrLibrary, ToastrOptions, ToastrMessage, ToastrNotification>(mvcBuilder, defaultOptions, nToastNotifyOptions);
        }
        /// <summary>
        /// Add the NToastNotify middleware to handle ajax request.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNToastNotify(this IApplicationBuilder builder)
        {
            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = GetEmbeddedFileProvider(),
                RequestPath = new PathString("/ntoastnotify")
            });
            builder.UseMiddleware<NtoastNotifyMiddleware>();
            return builder;
        }

        internal static IMvcBuilder AddNToastNotifyToMvcBuilder<TLibrary, TOption, TMessage, TNotificationImplementation>(this IMvcBuilder mvcBuilder,
                                                                                                                            TOption defaultLibOptions,
                                                                                                                            NToastNotifyOption nToastNotifyOptions = null)
            where TLibrary : class, ILibrary<TOption>, new()
            where TOption : class, ILibraryOptions
            where TMessage : class, IToastMessage
            where TNotificationImplementation : class, IToastNotification
        {
            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcBuilder?.AddRazorOptions(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            var services = mvcBuilder.Services;
            AddNToastNotifyToServiceCollection<TLibrary, TOption, TMessage, TNotificationImplementation>(services, defaultLibOptions, nToastNotifyOptions);
            return mvcBuilder;
        }
        internal static IMvcCoreBuilder AddNToastNotifyToMvcBuilder<TLibrary, TOption, TMessage, TNotificationImplementation>(this IMvcCoreBuilder mvcCoreBuilder,
                                                                                                                            TOption defaultLibOptions,
                                                                                                                            NToastNotifyOption nToastNotifyOptions = null)
            where TLibrary : class, ILibrary<TOption>, new()
            where TOption : class, ILibraryOptions
            where TMessage : class, IToastMessage
            where TNotificationImplementation : class, IToastNotification
        {
            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcCoreBuilder?.AddRazorViewEngine(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            var services = mvcCoreBuilder.Services;
            AddNToastNotifyToServiceCollection<TLibrary, TOption, TMessage, TNotificationImplementation>(services, defaultLibOptions, nToastNotifyOptions);
            return mvcCoreBuilder;
        }
        internal static IServiceCollection AddNToastNotifyToServiceCollection<TLibrary, TOption, TMessage, TNotificationImplementation>(this IServiceCollection services, TOption defaultLibOptions,
            NToastNotifyOption nToastNotifyOptions = null)
            where TLibrary : class, ILibrary<TOption>, new()
            where TOption : class, ILibraryOptions
            where TMessage : class, IToastMessage
            where TNotificationImplementation : class, IToastNotification
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(GetEmbeddedFileProvider());
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
