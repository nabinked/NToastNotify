using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NToastNotify
{
    public class ToastMessage
    {
        public ToastMessage(string message, string title, Enums.ToastType toasType, ILibraryOptions options = null)
        {
            this.Message = message;
            this.Title = title;
            this.ToastType = toasType;
            this.ToastOptions = options;
        }
        public string Title { get; set; }
        public string Message { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ToastType ToastType { get; set; }
        public ILibraryOptions ToastOptions { get; set; }
    }
}
