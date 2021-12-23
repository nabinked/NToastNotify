using NToastNotify;
using NToastNotify.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GenericStartupExtension
    {
        /// <summary>
        /// Add Generic toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcBuilder AddNToastNotifyGeneric<TOption>(this IMvcBuilder mvcBuilder, GenericOptions? defaultOptions = null,
            NToastNotifyOption? nToastNotifyOptions = null) where TOption : GenericOptions, new()
        {
            nToastNotifyOptions ??= new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<GenericLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<GenericNotification<TOption>>(library, nToastNotifyOptions);
        }

        /// <summary>
        /// Add Generic toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddNToastNotifyGeneric<TOption>(this IMvcCoreBuilder mvcBuilder, TOption? defaultOptions = null,
            NToastNotifyOption? nToastNotifyOptions = null) where TOption : GenericOptions, new()
        {
            nToastNotifyOptions ??= new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<GenericLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<GenericNotification<TOption>>(library, nToastNotifyOptions);
        }
    }
}
