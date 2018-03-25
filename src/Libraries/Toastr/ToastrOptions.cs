using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NToastNotify.Helpers;

namespace NToastNotify
{
    public class ToastrOptions: IToastrJsOptions, ILibraryOptions
    {
        public bool? TapToDismiss { get; set; }
        public string ToastClass { get; set; }
        public string ContainerId { get; set; }
        public bool? Debug { get; set; }
        public string ShowMethod { get; set; }
        public int? ShowDuration { get; set; }
        public string ShowEasing { get; set; }
        public string OnShown { get; set; }
        public string HideMethod { get; set; }
        public int? HideDuration { get; set; }
        public string HideEasing { get; set; }
        public string OnHidden { get; set; }
        public bool? CloseMethod { get; set; }
        public bool? CloseDuration { get; set; }
        public bool? CloseEasing { get; set; }
        public bool? CloseOnHover { get; set; }
        public int? ExtendedTimeOut { get; set; }
        /// <summary>
        /// Use the <see cref="IconClasses"/> to set the available values
        /// </summary>
        public string IconClass { get; set; }
        /// <summary>
        /// Use the <see cref="ToastPositions"/> to set the available values
        /// </summary>
        public string PositionClass { get; set; }
        public int? TimeOut { get; set; }
        public string TitleClass { get; set; }
        public string MessageClass { get; set; }
        public bool? EscapeHtml { get; set; }
        public string Target { get; set; }
        public string CloseHtml { get; set; }
        public string CloseClass { get; set; }
        public bool? NewestOnTop { get; set; }
        public bool? PreventDuplicates { get; set; }
        public bool? ProgressBar { get; set; }
        public bool? Rtl { get; set; }
        public bool? CloseButton { get; set; }
        public string Onclick { get; set; }

        //Non library options. Used purely for rendering purposes
        public string Title { get; set; }
        [JsonConverter(typeof(StringEnumConverter), true)]
        public Enums.NotificationTypesToastr Type { get; set; }

        //ILIbraryoptions
        string ILibraryOptions.Json => this.ToJson();
    }
}
