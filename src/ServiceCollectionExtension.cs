using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using Microsoft.AspNetCore.Builder;
using NToastNotify.Libraries;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using NToastNotify.Libraries.Toastr;

namespace NToastNotify
{
    public static class ServiceCollectionExtension
    {
        private static EmbeddedFileProvider _embeddedFileProvider = null;
        private static readonly Assembly ThisAssembly = typeof(Components.ToastrViewComponent).Assembly;
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
        public static IMvcBuilder AddNToastNotify(this IMvcBuilder mvcBuilder, ToastrOptions defaultOptions = null,
    NToastNotifyOption nToastNotifyOptions = null)
        {
            return AddNToastNotifyToMvcBuilder<ToastrLibrary, ToastrOptions, IToastrNotification, ToastrNotification>(mvcBuilder, defaultOptions, nToastNotifyOptions);
        }

        /// <summary>
        /// Add Toastr based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcBuilder AddNToastNotifyToastr(this IMvcBuilder mvcBuilder, ToastrOptions defaultOptions = null,
    NToastNotifyOption nToastNotifyOptions = null)
        {
            return AddNToastNotifyToMvcBuilder<ToastrLibrary, ToastrOptions, IToastrNotification, ToastrNotification>(mvcBuilder, defaultOptions ?? new ToastrOptions(), nToastNotifyOptions);
        }

        /// <summary>
        /// Add Noty based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcBuilder AddNToastNotifyNoty(this IMvcBuilder mvcBuilder, NotyOptions defaultOptions = null,
    NToastNotifyOption nToastNotifyOptions = null)
        {
            return AddNToastNotifyToMvcBuilder<NotyLibrary, NotyOptions, INotyNotification, NotyNotification>(mvcBuilder, defaultOptions ?? new NotyOptions(), nToastNotifyOptions);
        }

        /// <summary>
        /// Add the NToastNotify middleware to handle ajax request.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNToastNotify(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<NtoastNotifyMiddleware>();
            builder.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = GetEmbeddedFileProvider(),
                RequestPath = new PathString("/ntoastnotify"),
            });
            return builder;
        }

        private static IMvcBuilder AddNToastNotifyToMvcBuilder<TLibrary, TOption, TNotificationService, TNotificationImplementation>(this IMvcBuilder mvcBuilder, TOption defaultLibOptions,
            NToastNotifyOption nToastNotifyOptions = null)
            where TOption : class, ILibraryOptions
            where TLibrary : class, ILibrary, new()
            where TNotificationService : class, IToastNotification
            where TNotificationImplementation : class, TNotificationService
        {
            var services = mvcBuilder.Services;
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(GetEmbeddedFileProvider());
            });

            //This is a fix for Feature folders based project structure. Add the view location to ViewLocationExpanders.
            mvcBuilder?.AddRazorOptions(o =>
            {
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            //Check if a TempDataProvider is already registered.
            var tempDataProvider = services.FirstOrDefault(d => d.ServiceType == typeof(ITempDataProvider));
            if (tempDataProvider == null)
            {
                //Add a tempdata provider when one is not already registered
                services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            }

            //Add TempDataWrapper for accessing and adding values to tempdata.
            services.AddScoped<ITempDataWrapper, TempDataWrapper>();

            //check if IHttpContextAccessor implementation is not registered. Add one if not.
            var httpContextAccessor = services.FirstOrDefault(d => d.ServiceType == typeof(IHttpContextAccessor));
            if (httpContextAccessor == null)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }

            var library = new TLibrary();

            // Add the toast library default options that will be rendered by the viewcomponent
            services.AddSingleton<ILibraryOptions>(defaultLibOptions ?? library.Defaults);
            services.AddSingleton<ILibrary, TLibrary>();

            // Add the NToastifyOptions to the services container for DI retrieval 
            //(options that are not rendered as they are not part of the plugin)
            nToastNotifyOptions = nToastNotifyOptions ?? new NToastNotifyOption();
            nToastNotifyOptions.LibraryDetails = library;
            services.AddSingleton(nToastNotifyOptions);
            services.AddSingleton<IMessageContainerFactory, MessageContainerFactory>();
            //Add the ToastNotification implementation
            services.AddSingleton<TNotificationService, TNotificationImplementation>();
            services.AddSingleton<IToastNotification, TNotificationImplementation>();
            services.AddScoped<NtoastNotifyMiddleware>();
            return mvcBuilder;
        }
    }
}
