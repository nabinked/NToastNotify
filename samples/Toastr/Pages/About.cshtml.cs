using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Toastr.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IToastNotification _toastNotification;

        public AboutModel(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet()
        {
            _toastNotification.AddWarningToastMessage("This message is from About page before being redirected to Privacy page");
            return RedirectToPage("/Privacy");
        }
    }
}