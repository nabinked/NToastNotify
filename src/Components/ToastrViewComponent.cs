using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        private readonly IToastNotification _toastNotification;
        private readonly ToastOption _globalOption;                 // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs

        public ToastrViewComponent(IToastNotification toastNotification, ToastOption globalOption)
        {
            _toastNotification = toastNotification;
            _globalOption = globalOption;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel()
            {
                ToastMessages = _toastNotification.GetToastMessages(),
                GlobalOptionJson = _globalOption.MergeWith(ToastOption.Defaults).Json
            };
            return View("ToastrView", model);
        }
    }
}
