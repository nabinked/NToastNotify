using Microsoft.AspNetCore.Mvc;

namespace NToastNotify.Web.Controllers
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
            _toastNotification.AddSuccessToastMessage("Same for success message", "Success title specified in controller action");
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage();

            //Info
            _toastNotification.AddInfoToastMessage();

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage();

            _toastNotification.AddToastMessage("Custom Title", "My Custom Message", ToastEnums.ToastType.Success, new ToastOption()
            {
                PositionClass = ToastPositions.BottomLeft
            });

            var messages = _toastNotification.PeekToastMessages();
            return View();
        }

        public IActionResult About()
        {
            _toastNotification.AddToastMessage("Warning About Title", "My About Warning Message", ToastEnums.ToastType.Warning, new ToastOption()
            {
                PositionClass = ToastPositions.BottomFullWidth
            });

            return View();
        }

        public IActionResult Contact()
        {
            _toastNotification.AddToastMessage("Redirected...", "Dont get confused. <br /> You were redirected from Contact Page.", ToastEnums.ToastType.Info, new ToastOption()
            {
                PositionClass = ToastPositions.TopCenter
            });
            return RedirectToAction("About"); ;
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
    }
}
