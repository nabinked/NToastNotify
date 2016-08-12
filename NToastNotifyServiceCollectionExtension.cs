using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace NToastNotify
{
    public static class NToastNotifyServiceCollectionExtension
    {
        public static IServiceCollection AddNToastNotify(this IServiceCollection services)
        {
            var assembly = typeof(Components.ToastrViewComponent).GetTypeInfo().Assembly;

            //Create an EmbeddedFileProvider for that assembly
            var embeddedFileProvider = new EmbeddedFileProvider(
                assembly,
                "NToastNotify"
            );

            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });
            services.AddSingleton<IToastNotification, ToastNotification>();

            return services;
        }
    }
}
