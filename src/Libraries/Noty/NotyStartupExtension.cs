using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify.Libraries.Toastr;

namespace NToastNotify.Libraries.Noty
{
    public static class NotyStartupExtension
    {
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
            return mvcBuilder.AddNToastNotifyToMvcBuilder<NotyLibrary, NotyOptions, NotyMessage, INotyNotification, NotyNotification>(defaultOptions ?? new NotyOptions(), nToastNotifyOptions);
        }
    }
}
