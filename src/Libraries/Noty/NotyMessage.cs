using Newtonsoft.Json;
using NToastNotify.Attributes;

namespace NToastNotify
{
    public class NotyMessage : IToastMessage
    {
        public NotyMessage(string message, ILibraryOptions options = null)
        {
            Message = message;
            Options = options;
        }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        [JsonConverter(typeof(ConcreteTypeConverter<NotyOptions>))]
        public ILibraryOptions Options { get; private set; }
    }
}
