using NToastNotify;
using NToastNotify.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BootstrapStartupExtension
    {
        /// <summary>
        /// Add Bootstrap based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcBuilder AddNToastNotifyBootstrap(this IMvcBuilder mvcBuilder, BootstrapOptions? defaultOptions = null,
            NToastNotifyOption? nToastNotifyOptions = null)
        {
            nToastNotifyOptions ??= new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<BootstrapLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<BootstrapNotification>(library, nToastNotifyOptions);
        }

        /// <summary>
        /// Add Bootstrap based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddNToastNotifyBootstrap(this IMvcCoreBuilder mvcBuilder, BootstrapOptions? defaultOptions = null,
            NToastNotifyOption? nToastNotifyOptions = null)
        {
            nToastNotifyOptions ??= new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<BootstrapLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<BootstrapNotification>(library, nToastNotifyOptions);
        }
    }
}
