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
            _toastNotification.AddToastMessage("Success Title", "My Success Message", ToastEnums.ToastType.Success, new ToastOption()
            {
                PositionClass = ToastPositions.BottomLeft
            });

            _toastNotification.AddWarningToastMessage("WAIT WHAT HEADING??", "My Default Warning Message");
            return View();
        }

        public IActionResult About()
        {
            _toastNotification.AddToastMessage("Success About Title", "My About Warning Message", ToastEnums.ToastType.Warning, new ToastOption()
            {
                PositionClass = ToastPositions.BottomFullWidth
            });

            return View();
        }

        public IActionResult Contact()
        {
            _toastNotification.AddToastMessage("Redirected...", "You were redirected from Contact Page.", ToastEnums.ToastType.Info, new ToastOption()
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
    }
}
