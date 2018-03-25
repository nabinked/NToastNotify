using System;
using Microsoft.AspNetCore.Mvc;

namespace NToastNotify.Toastr.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            //Testing Default Methods

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

            return View();
        }

        public IActionResult About()
        {
            _toastNotification.AddInfoToastMessage("This is about page");
            return View();
        }

        public IActionResult Contact()
        {
            _toastNotification.AddAlertToastMessage("You will be redirected to about page");
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("There was something wrong with this request.");
            return View();
        }

        public IActionResult Empty()
        {

            return View();
        }

        public IActionResult Ajax()
        {
            _toastNotification.AddInfoToastMessage("This page will make ajax requests and show notifications.");
            return View();
        }

        public IActionResult AjaxCall()
        {
            System.Threading.Thread.Sleep(2000);
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax request. AJAX CALL " + DateTime.Now.ToLongTimeString());
            return PartialView("_PartialView", "Ajax Call");
        }

        public IActionResult NormalAjaxCall()
        {
            return PartialView("_PartialView", "Normal Ajax Call");
        }

        public IActionResult ErrorAjaxCall()
        {
            throw new Exception("Error occurred");
        }
    }
}
