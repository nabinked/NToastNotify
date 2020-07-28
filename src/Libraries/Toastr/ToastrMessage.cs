using System.Net;
using Newtonsoft.Json;
using NToastNotify.Attributes;

namespace NToastNotify
{
    public class ToastrMessage : IToastMessage
    {
        public ToastrMessage(string message, LibraryOptions? options = null)
        {
            Message = WebUtility.HtmlEncode(message);
            Options = options;
        }
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        [JsonConverter(typeof(ConcreteTypeConverter<ToastrOptions>))]
        public LibraryOptions? Options { get; private set; }

    }
}
