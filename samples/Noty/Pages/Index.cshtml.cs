using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Noty.Pages
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
            _toastNotification.AddSuccessToastMessage();
            _toastNotification.AddErrorToastMessage("Test m'e'ssag'e with single q'oute", new NotyOptions()
            {
                Timeout = 0,
                Layout = "topLeft",
                Theme = "mint"
            });


            //Info
            _toastNotification.AddInfoToastMessage(null, new NotyOptions
            {
                Layout = "bottomLeft"
            });
            _toastNotification.AddInfoToastMessage("This is an info toast", new NotyOptions()
            {
                ProgressBar = false,
                Layout = "center"
            });

            //Warning
            _toastNotification.AddWarningToastMessage("Waring go bottom right", new NotyOptions()
            {
                Layout = "bottomRight"
            });

            //Error
            _toastNotification.AddErrorToastMessage("Custom Error Message", new NotyOptions() { Theme = "mint" });
        }
    }
}
