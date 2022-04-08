using Newtonsoft.Json;
using NToastNotify.Attributes;

namespace NToastNotify
{
    public class GenericMessage<TOption> : IToastMessage where TOption : GenericOptions?, new()
    {
        public GenericMessage()
        {
            Message = "";
        }
        public GenericMessage(string message, LibraryOptions? options = null)
        {
            Message = message;
            Options = (TOption?)options;
        }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        public TOption? Options { get; private set; }

        [JsonIgnore]
        LibraryOptions? IToastMessage.Options => Options;
    }
}
