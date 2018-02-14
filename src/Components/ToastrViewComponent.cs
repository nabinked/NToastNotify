using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using NToastNotify.Helpers;
using NToastNotify.Libraries;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ILibraryOptions _globalOption; // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs
        private readonly ILibrary _library;
        private readonly NToastNotifyOption _nToastNotifyOption;

        public ToastrViewComponent(IToastNotification toastNotification, ILibraryOptions globalOption,
                                        ILibrary library, NToastNotifyOption nToastNotifyOption)
        {
            _toastNotification = toastNotification;
            _globalOption = globalOption;
            _library = library;
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
                LibraryDetails = _library
            };
            return View("ToastrView", model);
        }
    }
}
