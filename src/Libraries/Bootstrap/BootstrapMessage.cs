using Newtonsoft.Json;
using NToastNotify.Attributes;

namespace NToastNotify
{
    public class BootstrapMessage : IToastMessage
    {
        public BootstrapMessage(string message, LibraryOptions? options = null)
        {
            Message = message;
            Options = options;
        }

        [JsonProperty]
        public string Message { get; private set; }

        [JsonProperty]
        [JsonConverter(typeof(ConcreteTypeConverter<BootstrapOptions>))]
        public LibraryOptions? Options { get; private set; }
    }
}
