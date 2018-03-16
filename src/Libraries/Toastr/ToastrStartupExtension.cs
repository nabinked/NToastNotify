using Microsoft.Extensions.DependencyInjection;
using NToastNotify.Libraries.Noty;

namespace NToastNotify.Libraries.Toastr
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
            return mvcBuilder.AddNToastNotifyToMvcBuilder<ToastrLibrary, ToastrOptions, ToastrMessage, IToastrNotification, ToastrNotification>(defaultOptions ?? new ToastrOptions(), nToastNotifyOptions);
        }
    }
}
