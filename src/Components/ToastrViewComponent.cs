using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        private readonly ToastOption _globalOption;                 // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs
        private readonly ITempDataWrapper _tempDataWrapper;

        public ToastrViewComponent(ITempDataWrapper tempDataWrapper, ToastOption globalOption)
        {
            _tempDataWrapper = tempDataWrapper;
            _globalOption = globalOption;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel()
            {
                ToastMessages = _tempDataWrapper.Get<IEnumerable<ToastMessage>>(Constants.TempDataKey),
                GlobalOptionJson = _globalOption.MergeWith(ToastOption.Defaults).Json
            };
            return View("ToastrView", model);
        }
    }
}
