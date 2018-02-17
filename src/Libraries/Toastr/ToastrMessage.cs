using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NToastNotify
{
    public class ToastrMessage : IToastMessage
    {
        public ToastrMessage(string message, string title, Enums.NotificationTypesToastr toasType, ILibraryOptions options = null)
        {
            this.Message = message;
            this.Title = title;
            this.ToastType = toasType.ToString();
            this.ToastOptions = options;
        }
        [JsonProperty]
        public string Title { get; private set; }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        public string ToastType { get; private set; }
        [JsonProperty]
        public ILibraryOptions ToastOptions { get; private set; }
    }
}
