using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using NToastNotify.Libraries;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ToastrStartupExtension
    {
        /// <summary>
        /// Add Noty based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcBuilder AddNToastNotifyToastr(this IMvcBuilder mvcBuilder, ToastrOptions defaultOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
        {
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrLibrary, ToastrOptions, ToastrMessage, ToastrNotification>(defaultOptions ?? new ToastrOptions(), nToastNotifyOptions);
        }

        /// <summary>
        /// Add Noty based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddNToastNotifyToastr(this IMvcCoreBuilder mvcBuilder, ToastrOptions defaultOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
        {
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrLibrary, ToastrOptions, ToastrMessage, ToastrNotification>(defaultOptions ?? new ToastrOptions(), nToastNotifyOptions);
        }
    }
}
