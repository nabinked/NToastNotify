using NToastNotify.Libraries;
using System.Collections.Generic;

namespace NToastNotify
{
    public class ToastNotificationViewModel
    {
        public string ToastMessagesJson { get; set; }
        public string GlobalOptionJson { get; set; }
        public string RequestHeaderKey { get; set; }
        public string ResponseHeaderKey { get; set; }
        public ILibrary LibraryDetails { get; set; }
    }
}
