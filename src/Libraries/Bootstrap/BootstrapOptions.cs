using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NToastNotify.Helpers;

namespace NToastNotify
{
    public class BootstrapOptions : LibraryOptions
    {
        public string TemplateId { get; set; } = "bootstrap-toast-template";

        public string ContainerId { get; set; } = "bootstrap-toast-container";

        public string? PositionClass { get; set; }

        [JsonConverter(typeof(StringEnumConverter), true)]
        public Enums.NotificationTypesBootstrap Type { get; set; }

        public override string Json => this.ToJson();
    }
}
