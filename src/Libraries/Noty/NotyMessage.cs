using Newtonsoft.Json;
using NToastNotify.Attributes;

namespace NToastNotify.Libraries
{
    public class NotyMessage : IToastMessage
    {
        public NotyMessage(string message, ILibraryOptions options = null)
        {
            Message = message;
            ToastOptions = options;
        }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        [JsonConverter(typeof(ConcreteTypeConverter<NotyOptions>))]
        public ILibraryOptions ToastOptions { get; private set; }
    }
}
