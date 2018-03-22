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
        public static IMvcBuilder AddNToastNotifyToastr(this IMvcBuilder mvcBuilder, IToastrJsOptions defaultOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
        {
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrLibrary, IToastrJsOptions, ToastrMessage, ToastrNotification>(defaultOptions ?? new IToastrJsOptions(), nToastNotifyOptions);
        }

        /// <summary>
        /// Add Noty based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddNToastNotifyToastr(this IMvcCoreBuilder mvcBuilder, IToastrJsOptions defaultOptions = null,
            NToastNotifyOption nToastNotifyOptions = null)
        {
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrLibrary, IToastrJsOptions, ToastrMessage, ToastrNotification>(defaultOptions ?? new IToastrJsOptions(), nToastNotifyOptions);
        }
    }
}
