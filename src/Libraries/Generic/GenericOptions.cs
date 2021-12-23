using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NToastNotify.Helpers;
using static NToastNotify.Enums;

namespace NToastNotify
{
    public class GenericOptions : LibraryOptions
    {
        public override string Json => this.ToJson();

        [JsonConverter(typeof(StringEnumConverter), true)]
        public NotificationTypesGeneric Type { get; set; }
    }
}
