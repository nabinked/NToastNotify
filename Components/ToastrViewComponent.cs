using Microsoft.AspNetCore.Mvc;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        public IToastNotification ToastNotification { get; set; }

        public ToastrViewComponent(IToastNotification toastNotification)
        {
            ToastNotification = toastNotification;
        }

        public IViewComponentResult Invoke()
        {
            return View("ToastrView", ToastNotification);
        }

    }
}
