using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NToastNotify.Libraries;
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
            _toastNotification.AddErrorToastMessage("Test Erro", null, new NotyOptions()
            {
                Timeout = 0
            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _toastNotification.AddAlertToastMessage("Warning About Title", "My About Warning Message");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            _toastNotification.AddInfoToastMessage("Redirected...", "Dont get confused. <br /> <strong>You were redirected from Contact Page. <strong/>");
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("ERROR", "There was something wrong with this request.");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        public IActionResult NormalAjaxCall()
        {
            return PartialView("_PartialView");
        }
    }
}
