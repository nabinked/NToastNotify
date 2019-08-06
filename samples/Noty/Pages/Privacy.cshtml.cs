using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Noty.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IToastNotification _toastNotification;

        public PrivacyModel(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {
            _toastNotification.AddWarningToastMessage("Privacyyyyyyyyyyyyy");
        }
    }
}