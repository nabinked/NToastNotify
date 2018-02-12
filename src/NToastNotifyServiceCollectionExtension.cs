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

namespace NToastNotify
{
    public static class NToastNotifyServiceCollectionExtension
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

        public static IMvcBuilder AddNToastNotify<TOptions>(this IMvcBuilder mvcBuilder, TOptions defaultOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
            where TOptions : class, ILibraryOptions

        {
            return AddNToastNotifyToMvcBuilder<TOptions>(mvcBuilder, defaultOptions, nToastNotifyOptions);
        }

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

        private static IMvcBuilder AddNToastNotifyToMvcBuilder<T, TOptions>(this IMvcBuilder mvcBuilder, TOptions defaultLibOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
            where T : class, ILibrary<TOptions>
            where TOptions : class, ILibraryOptions
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

            //Add the ToastNotification implementation
            services.AddSingleton<IToastNotification<ILibraryOptions>, ToastNotification>();

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
            services.AddSingleton<ILibraryOptions>(defaultLibOptions ?? default(ILibraryOptions));

            // Add the NToastifyOptions to the services container for DI retrieval (options that are not rendered as they are not part of the toastr.js plugin)
            nToastNotifyOptions = nToastNotifyOptions ?? new NToastNotifyOption();
            services.AddSingleton((NToastNotifyOption)nToastNotifyOptions);
            services.AddSingleton<IMessageContainerFactory, MessageContainerFactory>();
            services.AddScoped<NtoastNotifyMiddleware>();
            return mvcBuilder;
        }
    }
}
