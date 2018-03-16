using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using NToastNotify.Helpers;
using NToastNotify.Libraries;

namespace NToastNotify.Components
{
    [ViewComponent(Name = "NToastNotify.Toastr")]
    public class ToastrViewComponent : ViewComponent
    {
        private readonly IToastMessagesAccessor<IToastMessage<ILibraryOptions>> _toastMessagesAccessor;
        private readonly ILibraryOptions _globalOption; // This is filled with the provided default values on NToastNotify service config./initialization in startup.cs
        private readonly NToastNotifyOption _nToastNotifyOption;

        public ToastrViewComponent(IToastMessagesAccessor<IToastMessage<ILibraryOptions>> toastMessagesAccessor, ILibraryOptions globalOption, NToastNotifyOption nToastNotifyOption)
        {
            _toastMessagesAccessor = toastMessagesAccessor;
            _globalOption = globalOption;
            _nToastNotifyOption = nToastNotifyOption;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ToastNotificationViewModel()
            {
                ToastMessagesJson = _toastMessagesAccessor.ToastMessages.ToJson(),
                GlobalOptionJson = _globalOption.Json,
                ResponseHeaderKey = Constants.ResponseHeaderKey,
                RequestHeaderKey = Constants.RequestHeaderKey,
                LibraryDetails = _nToastNotifyOption.LibraryDetails
            };
            return View("ToastrView", model);
        }
    }
}
