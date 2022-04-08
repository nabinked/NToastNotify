using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using NToastNotify.Helpers;

namespace GenericDevExtreme.Pages
{
    public class FormPostModel : PageModel
    {
        private readonly IToastNotification _toastNotification;

        public FormPostModel(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(string input, string redirect)
        {
            _toastNotification.AddSuccessToastMessage("Input received: " + input, new DevExtremeToastOptions { DisplayTime = 3000 });
            if (redirect == "on")
                return RedirectToPage("/Privacy");
            return Page();
        }
    }
}