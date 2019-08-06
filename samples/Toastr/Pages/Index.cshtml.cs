using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Toastr.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IToastNotification _toastNotification;

        public IndexModel(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {
            //Success
            _toastNotification.AddSuccessToastMessage("Same for success message", new ToastrOptions()
            {
                Title = "Yeah !"
            });
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage();

            //Info
            _toastNotification.AddInfoToastMessage();
            _toastNotification.AddInfoToastMessage("This is an info toast", new ToastrOptions()
            {
                ProgressBar = false
            });

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage("Custom Error Message", new ToastrOptions() { Title = "Oops" });
        }
    }
}
