using Microsoft.AspNetCore.Mvc;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        private readonly ToastOption _globalOption;
        public IToastNotification ToastNotification { get; set; }

        public ToastrViewComponent(IToastNotification toastNotification, ToastOption globalOption)
        {
            _globalOption = globalOption;
            ToastNotification = toastNotification;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel()
            {
                ToastMessages = ToastNotification.GetToastMessages(),
                GlobalOptionJson = _globalOption.MergeWith(ToastOption.Defaults).Json
            };
            return View("ToastrView", model);
        }

    }
}
