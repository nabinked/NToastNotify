using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NToastNotify.Helpers;
using static NToastNotify.Enums;

namespace NToastNotify
{
    public class NotyOptions : LibraryOptions
    {
        /// <summary>
        /// alert, success, error, warning, info - ClassName generator uses this value → noty_type__${type}
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter), true)]
        public NotificationTypesNoty Type { get; set; }
        /// <summary>
        /// top, topLeft, topCenter, topRight, center, centerLeft, centerRight, bottom, bottomLeft, bottomCenter, bottomRight - ClassName generator uses this value → noty_layout__${layout}
        /// </summary>
        public string? Layout { get; set; }
        /// <summary>
        /// relax, mint, metroui - ClassName generator uses this value → noty_theme__${theme}
        /// </summary>
        public string? Theme { get; set; }
        /// <summary>
        /// This string can contain HTML too. But be careful and don't pass user inputs to this parameter.
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// 0, 1000, 3000, 3500, etc. Delay for closing event in milliseconds (ms). Set 0 for sticky notifications.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// true, false - Displays a progress bar if timeout is not false.
        /// </summary>
        public bool? ProgressBar { get; set; }
        /// <summary>
        /// click, button
        /// </summary>
        public string[]? CloseWith { get; set; }
        /// <summary>
        /// v3.1.0-beta Behaves like v2 but more stable
        /// </summary>
        public bool? Modal { get; set; }
        /// <summary>
        /// You can use this id with querySelectors. Generated automatically if false.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// DOM insert method depends on this parameter. If false uses append, if true uses prepend.
        /// </summary>
        public bool? Force { get; set; }
        /// <summary>
        /// NEW Named queue system. Details are https://ned.im/noty/#/api.
        /// </summary>
        public string? Queue { get; set; }
        /// <summary>
        /// Custom container selector string. Like '.my-custom-container'. Layout parameter will be ignored.
        /// </summary>
        public string? Container { get; set; }
        /// <summary>
        /// If true Noty uses PageVisibility API to handle timeout. To ensure that users do not miss their notifications.
        /// </summary>
        public bool? VisibilityControl { get; set; }

        public override string Json => this.ToJson();
    }
}