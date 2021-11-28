using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Noty.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string _version;
        private readonly IToastNotification _toastNotification;
        //private readonly NotyNotification _toastNotification;

        public IndexModel(IToastNotification toastNotification)
        {
            _version = Assembly.GetAssembly(typeof(IToastNotification))?.GetName().Version?.ToString() ?? throw new Exception("Version not found");
            _toastNotification = toastNotification;
            //_toastNotification = toastNotification as NotyNotification;
        }
        public void OnGet()
        {
            _toastNotification.AddSuccessToastMessage();
            _toastNotification.AddErrorToastMessage("Test m'e'ssag'e with single q'oute. Version: " + _version, new NotyOptions()
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
            _toastNotification.AddInfoToastMessage("This is an info toast. Version: " + _version, new NotyOptions()
            {
                ProgressBar = false,
                Layout = "center"
            });

            //Warning
            _toastNotification.AddWarningToastMessage("Waring go bottom right. Version: " + _version, new NotyOptions()
            {
                Layout = "bottomRight"
            });

            //Error
            _toastNotification.AddErrorToastMessage("Custom Error Message. Version: " + _version, new NotyOptions() { Theme = "mint" });
        }
    }
}
