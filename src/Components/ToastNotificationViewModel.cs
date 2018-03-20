using Microsoft.Extensions.FileProviders;
using NToastNotify.Libraries;

namespace NToastNotify.Components
{
    public class ToastNotificationViewModel
    {
        public string ToastMessagesJson { get; set; }
        public string GlobalOptionJson { get; set; }
        public string RequestHeaderKey { get; set; }
        public string ResponseHeaderKey { get; set; }
        public ILibrary<ILibraryOptions> LibraryDetails { get; set; }
        public string Hash { get; set; }
    }
}
