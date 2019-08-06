using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Toastr.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IToastNotification _toastNotification;

        public PrivacyModel(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {
            _toastNotification.AddInfoToastMessage("Privacy is important");
        }
    }
}