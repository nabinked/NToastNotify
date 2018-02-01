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

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ajax()
        {
            _toastNotification.AddSuccessToastMessage("Yay!! You got an ajax toast notification.", "AJAX Success");
            return Content("AJAX CALL");
        }
    }
}
