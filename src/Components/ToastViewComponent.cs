using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using NToastNotify.Helpers;
using NToastNotify.Libraries;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify")]
    public class ToastViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ILibraryOptions _globalOption; // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs
        private readonly NToastNotifyOption _nToastNotifyOption;

        public ToastViewComponent(IToastNotification toastNotification, ILibraryOptions globalOption, NToastNotifyOption nToastNotifyOption, IFileProvider fileProvider)
        {
            _toastNotification = toastNotification;
            _globalOption = globalOption;
            _nToastNotifyOption = nToastNotifyOption;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel()
            {
                ToastMessagesJson = _toastNotification.ReadAllMessages().ToJson(),
                GlobalOptionJson = _globalOption.Json,
                ResponseHeaderKey = Constants.ResponseHeaderKey,
                RequestHeaderKey = Constants.RequestHeaderKey,
                LibraryDetails = _nToastNotifyOption.LibraryDetails,
                Hash = Utils.GetEmbeddedFileProvider().GetFileInfo($"js.dist.{_nToastNotifyOption.LibraryDetails.VarName}.js").LastModified.DateTime.ToString("yyyyMMddhhss")
            };
            return View("ToastView", model);
        }
    }
}
