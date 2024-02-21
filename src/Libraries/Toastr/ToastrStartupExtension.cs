using NToastNotify;
using NToastNotify.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ToastrStartupExtension
    {
        /// <summary>
        /// Add Toastr based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcBuilder AddNToastNotifyToastr(this IMvcBuilder mvcBuilder, ToastrOptions? defaultOptions = null,
            NToastNotifyOption? nToastNotifyOptions = null)
        {
            nToastNotifyOptions ??= new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<ToastrLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrNotification>(library, nToastNotifyOptions);
        }

        /// <summary>
        /// Add Toastr based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddNToastNotifyToastr(this IMvcCoreBuilder mvcBuilder, ToastrOptions? defaultOptions = null,
            NToastNotifyOption? nToastNotifyOptions = null)
        {
            nToastNotifyOptions ??= new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<ToastrLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrNotification>(library, nToastNotifyOptions);
        }
    }
}
