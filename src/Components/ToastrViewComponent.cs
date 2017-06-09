using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        public IToastNotification ToastNotification { get; set; }

        public ToastrViewComponent(IToastNotification toastNotification)
        {
            ToastNotification = toastNotification;
        }

        public IViewComponentResult Invoke()
        {
            return View("ToastrView", ToastNotification.GetToastMessages());
        }

    }
}
