using System.Collections.Generic;

namespace NToastNotify
{
    public class ToastNotificationViewModel
    {
        public IEnumerable<ToastMessage> ToastMessages { get; set; }
        public string GlobalOptionJson { get; set; }
    }
}
