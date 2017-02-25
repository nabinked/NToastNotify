using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NToastNotify.Web.Controllers
{
    public class HomeController : Controller
    {
        private IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            _toastNotification.AddToastMessage("Success Title", "My Warning Message", ToastEnums.ToastType.Warning, new ToastOption()
            {
                PositionClass = NToastNotify.Constants.ToastPositions.BottomFullWidth
            });

            _toastNotification.AddToastMessage("Success Title", "My Success Message", ToastEnums.ToastType.Success, new ToastOption()
            {
                PositionClass = NToastNotify.Constants.ToastPositions.BottomRight
            });

            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _toastNotification.AddToastMessage("Success About Title", "My About Warning Message", ToastEnums.ToastType.Warning, new ToastOption()
            {
                PositionClass = NToastNotify.Constants.ToastPositions.BottomFullWidth
            });

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            _toastNotification.AddToastMessage("Redirected...", "You were redirected from Contact Page.", ToastEnums.ToastType.Info, new ToastOption()
            {
                PositionClass = NToastNotify.Constants.ToastPositions.TopCenter
            });
            return RedirectToAction("About"); ;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
