using System;
using Microsoft.AspNetCore.Mvc;
using NToastNotify.Libraries;
using NToastNotify.Libraries.Toastr;

namespace NToastNotify.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToastrNotification _toastNotification;

        public HomeController(IToastrNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            //Testing Default Methods

            //Success
            _toastNotification.AddSuccessToastMessage("Same for success message", "Success title specified in controller action");
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage();

            //Info
            _toastNotification.AddInfoToastMessage();

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage();

            _toastNotification.AddToastMessage("Custom Title", "My Custom Message", Enums.NotificationTypesToastr.Success, new ToastrOptions()
            {
                PositionClass = ToastPositions.TopLeft
            });

            return View();
        }

        public IActionResult About()
        {
            _toastNotification.AddToastMessage("Warning About Title", "My About Warning Message", Enums.NotificationTypesToastr.Warning, new ToastrOptions()
            {
                PositionClass = ToastPositions.BottomFullWidth
            });

            return View();
        }

        public IActionResult Contact()
        {
            _toastNotification.AddToastMessage("Redirected...", "Dont get confused. <br /> <strong>You were redirected from Contact Page. <strong/>", Enums.NotificationTypesToastr.Info, new ToastrOptions()
            {
                PositionClass = ToastPositions.TopCenter
            });
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("ERROR", "There was something wrong with this request.");
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
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax request.", "AJAX CALL " + DateTime.Now.ToLongTimeString());
            return PartialView("_PartialView");
        }
    }
}
