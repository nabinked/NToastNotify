using Newtonsoft.Json;
using NToastNotify.Attributes;
using NToastNotify.Libraries;

namespace NToastNotify
{
    public class ToastrMessage : IToastMessage
    {
        public ToastrMessage(string message, string title, Enums.NotificationTypesToastr toasType, ILibraryOptions options = null)
        {
            Message = message;
            Title = title;
            ToastType = toasType.ToString();
            ToastOptions = options;
        }
        [JsonProperty]
        public string Title { get; private set; }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        public string ToastType { get; private set; }
        [JsonProperty]
        [JsonConverter(typeof(ConcreteTypeConverter<ToastrOptions>))]
        public ILibraryOptions ToastOptions { get; private set; }

    }
}
