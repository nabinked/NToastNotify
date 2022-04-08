using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace GenericDevExtreme.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string? _version;
        private readonly IToastNotification _toastNotification;
        //private readonly ToastrNotification _toastNotification;

        public IndexModel(IToastNotification toastNotification)
        {
            _version = Assembly.GetAssembly(typeof(IToastNotification))?.GetName().Version?.ToString() ?? throw new Exception("Version not found");
            _toastNotification = toastNotification;
            //_toastNotification = toastNotification as ToastrNotification;
        }
        public void OnGet()
        {
            //Success
            _toastNotification.AddSuccessToastMessage("Same for success message. Version: " + _version, new DevExtremeToastOptions()
            {
                DisplayTime = 6000
            });
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage();

            //Info
            _toastNotification.AddInfoToastMessage();
            _toastNotification.AddInfoToastMessage("This is an info toast. Version: " + _version, new DevExtremeToastOptions()
            {
                DisplayTime = 8000
            });

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage("Custom Error Message. Version: " + _version, new DevExtremeToastOptions() { DisplayTime = 3000 });
        }
    }
}
