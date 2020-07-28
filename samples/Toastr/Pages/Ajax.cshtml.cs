using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Toastr.Pages
{
    public class AjaxModel : PageModel
    {
        private readonly IToastNotification _toastNotification;

        public AjaxModel(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public JsonResult OnGet(string type)
        {
            System.Threading.Thread.Sleep(2000);
            _toastNotification.AddSuccessToastMessage($"This toast is shown on Ajax request. Type: {type} " + DateTime.Now.ToLongTimeString());
            return new JsonResult(new { ok = true });
        }

    }
}