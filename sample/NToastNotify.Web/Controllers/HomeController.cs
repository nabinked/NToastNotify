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
            _toastNotification.AddSuccessToastMessage("Same for success message");
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage();

            //Info
            _toastNotification.AddInfoToastMessage();

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage();

            return View();
        }

        public IActionResult About()
        {
            _toastNotification.AddInfoToastMessage("You got redirected");
            return View();
        }

        public IActionResult Contact()
        {
            _toastNotification.AddAlertToastMessage("You will be redirected");
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
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax request. AJAX CALL " + DateTime.Now.ToLongTimeString());
            return PartialView("_PartialView");
        }
    }
}
