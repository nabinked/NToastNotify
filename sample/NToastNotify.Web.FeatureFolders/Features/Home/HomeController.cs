using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NToastNotify.Web.FeatureFolders.Models;

namespace NToastNotify.Web.FeatureFolders.Features.Home
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
            _toastNotification.AddSuccessToastMessage();
            _toastNotification.AddErrorToastMessage("Test Erro", null, new ToastOption()
            {
                PositionClass = ToastPositions.BottomCenter
            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _toastNotification.AddToastMessage("Warning About Title", "My About Warning Message", Enums.ToastType.Warning, new ToastOption()
            {
                PositionClass = ToastPositions.BottomFullWidth
            }); 
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            _toastNotification.AddToastMessage("Redirected...", "Dont get confused. <br /> <strong>You were redirected from Contact Page. <strong/>", Enums.ToastType.Info, new ToastOption()
            {
                PositionClass = ToastPositions.TopCenter
            });
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("ERROR", "There was something wrong with this request.");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ajax()
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

            _toastNotification.AddToastMessage("Custom Title", "My Custom Message", Enums.ToastType.Success, new ToastOption()
            {
                PositionClass = ToastPositions.BottomLeft
            });
            return Content("AJAX CALL");
        }
    }
}
