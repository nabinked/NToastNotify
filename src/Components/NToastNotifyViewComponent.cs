using Microsoft.AspNetCore.Mvc;
using NToastNotify.Components;
using NToastNotify.Helpers;

namespace NToastNotify
{
    [ViewComponent(Name = "NToastNotify")]
    public class NToastNotifyViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ILibrary _library;
        private readonly NToastNotifyOption _nToastNotifyOption;

        public NToastNotifyViewComponent(IToastNotification toastNotification, ILibrary library, NToastNotifyOption nToastNotifyOption)
        {
            _toastNotification = toastNotification;
            _library = library;
            _nToastNotifyOption = nToastNotifyOption;
        }

        public IViewComponentResult Invoke()
        {
            var assemblyName = GetType().Assembly.GetName();
            var model = new ToastNotificationViewModel(
                toastMessagesJson: JsonOrUndefined(_toastNotification.ReadAllMessages()),
                requestHeaderKey: Constants.RequestHeaderKey,
                responseHeaderKey: Constants.ResponseHeaderKey,
                libraryDetails: _library,
                disableAjaxToasts: _nToastNotifyOption.DisableAjaxToasts,
                libraryJsPath: $"~/_content/{assemblyName.Name}/{_library.VarName}.js?{assemblyName.Version}");

            return View("Default", model);
        }

        public string JsonOrUndefined(object obj)
        {
            return obj == null ? "undefined" : obj.ToJson();
        }
    }
}