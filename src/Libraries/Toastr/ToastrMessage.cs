using Newtonsoft.Json;
using NToastNotify.Attributes;
using NToastNotify.Libraries;

namespace NToastNotify
{
    public class ToastrMessage : IToastMessage
    {
        public ToastrMessage(string message, ILibraryOptions options = null)
        {
            Message = message;
            ToastOptions = options;
        }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        [JsonConverter(typeof(ConcreteTypeConverter<IToastrJsOptions>))]
        public ILibraryOptions ToastOptions { get; private set; }

    }
}
