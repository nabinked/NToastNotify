using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using NToastNotify.Helpers;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ToastOption _globalOption;                 // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs
        private readonly NToastNotifyOption _nToastNotifyOption;

        public ToastrViewComponent(IToastNotification toastNotification, ToastOption globalOption, NToastNotifyOption nToastNotifyOption)
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
                GlobalOptionJson = _globalOption.MergeWith(ToastOption.Defaults).Json,
                ResponseHeaderKey = Constants.ResponseHeaderKey,
                RequestHeaderKey = Constants.RequestHeaderKey,
                LibraryName = _nToastNotifyOption.Library.ToString().ToLower()
            };
            return View("ToastrView", model);
        }
    }
}
