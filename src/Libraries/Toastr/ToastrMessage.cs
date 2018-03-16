using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NToastNotify
{
    public class ToastrMessage : IToastMessage<ToastrOptions>
    {
        public ToastrMessage(string message, string title, Enums.NotificationTypesToastr toasType, ToastrOptions options = null)
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
        public ToastrOptions ToastOptions { get; private set; }
    }
}
