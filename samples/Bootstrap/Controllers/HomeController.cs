using Bootstrap.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;

namespace Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly ILibrary _library;

        public HomeController(ILogger<HomeController> logger, IToastNotification toastNotification, ILibrary library)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _library = library;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowToast(string notificationTypesBootstrap, string text = "Bootstrap toast")
        {
            switch (notificationTypesBootstrap)
            {
                case "Success":
                    _toastNotification.AddSuccessToastMessage(text);
                    break;
                case "Warning":
                    _toastNotification.AddWarningToastMessage(text);
                    break;
                case "Info":
                    _toastNotification.AddInfoToastMessage(text);
                    break;
                case "Error":
                    _toastNotification.AddErrorToastMessage(text);
                    break;
                case "Alert":
                    _toastNotification.AddAlertToastMessage(text + " (BottomLeft)", new BootstrapOptions { PositionClass = BootstrapPositions.BottomLeft });
                    break;
                default:
                    _toastNotification.AddErrorToastMessage("Unknown toast-type: " + notificationTypesBootstrap);
                    break;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
