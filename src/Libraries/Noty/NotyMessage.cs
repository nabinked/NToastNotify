using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NToastNotify
{
    public class NotyMessage : IToastMessage
    {
        public NotyMessage(string message, string title, NotyOptions options = null)
        {
            this.Message = message;
            this.Title = title;
            this.ToastOptions = options;
        }
        [JsonProperty]
        public string Title { get; private set; }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        public ILibraryOptions ToastOptions { get; private set; }
    }
}
