using Microsoft.AspNetCore.Mvc;
using NToastNotify.Helpers;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify")]
    public class ToastViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ILibraryOptions _globalOption; // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs
        private readonly ILibrary _library;

        public ToastViewComponent(IToastNotification toastNotification, ILibraryOptions globalOption, ILibrary library)
        {
            _toastNotification = toastNotification;
            _globalOption = globalOption;
            _library = library;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel()
            {
                ToastMessagesJson = _toastNotification.ReadAllMessages().ToJson(),
                GlobalOptionJson = _globalOption.Json,
                ResponseHeaderKey = Constants.ResponseHeaderKey,
                RequestHeaderKey = Constants.RequestHeaderKey,
                LibraryDetails = _library,
                Hash = Utils.GetEmbeddedFileProvider().GetFileInfo($"js.dist.{_library.VarName}.js").LastModified.DateTime.ToString("yyyyMMddhhss")
            };
            return View("ToastView", model);
        }
    }
}
