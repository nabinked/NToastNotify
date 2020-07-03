using NToastNotify;
using NToastNotify.Helpers;

namespace Microsoft.Extensions.DependencyInjection
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
        public static IMvcBuilder AddNToastNotifyNoty(this IMvcBuilder mvcBuilder,
                                                        NotyOptions? defaultOptions = null,
                                                        NToastNotifyOption? nToastNotifyOptions = null)
        {
            nToastNotifyOptions = nToastNotifyOptions ?? new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<NotyLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<NotyNotification>(library, nToastNotifyOptions);
        }

        /// <summary>
        /// Add Noty based toast notification services
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="nToastNotifyOptions"></param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddNToastNotifyNoty(this IMvcCoreBuilder mvcBuilder,
                                                            NotyOptions? defaultOptions = null,
                                                            NToastNotifyOption? nToastNotifyOptions = null)
        {
            nToastNotifyOptions = nToastNotifyOptions ?? new NToastNotifyOption();
            var library = Utils.GetLibraryDetails<NotyLibrary>(nToastNotifyOptions, defaultOptions);
            return mvcBuilder.AddNToastNotifyToMvcBuilder<NotyNotification>(library, nToastNotifyOptions);
        }
    }
}
