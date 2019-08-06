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
        public JsonResult OnGet()
        {
            System.Threading.Thread.Sleep(2000);
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax request. AJAX CALL " + DateTime.Now.ToLongTimeString());
            return new JsonResult(new { ok = true });
        }

    }
}