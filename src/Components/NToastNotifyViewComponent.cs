using Microsoft.AspNetCore.Mvc;
using NToastNotify.Components;
using NToastNotify.Helpers;

// ReSharper disable once CheckNamespace
namespace NToastNotify
{
    [ViewComponent(Name = "NToastNotify")]
    public class NToastNotifyViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ILibrary _library;

        public NToastNotifyViewComponent(IToastNotification toastNotification, ILibrary library)
        {
            _toastNotification = toastNotification;
            _library = library;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel
            {
                ToastMessagesJson = JsonOrUndefined(_toastNotification.ReadAllMessages()),
                ResponseHeaderKey = Constants.ResponseHeaderKey,
                RequestHeaderKey = Constants.RequestHeaderKey,
                LibraryDetails = _library,
                Hash = Utils.GetEmbeddedFileProvider().GetFileInfo($"js.dist.{_library.VarName}.js").LastModified.DateTime.ToString("yyyyMMddhhss")
            };
            return View("Default", model);
        }

        public string JsonOrUndefined(object obj)
        {
            return obj == null ? "undefined" : obj.ToJson();
        }
    }
}
