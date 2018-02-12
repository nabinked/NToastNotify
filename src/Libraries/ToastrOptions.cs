using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NToastNotify.Helpers;

namespace NToastNotify
{
    public class ToastrOptions : ILibraryOptions
    {
        public bool? TapToDismiss { get; set; } = true;
        public string ToastClass { get; set; } = "toast";
        public string ContainerId { get; set; } = "toast-container";
        public bool? Debug { get; set; } = false;
        public string ShowMethod { get; set; } = "fadeIn";
        public int? ShowDuration { get; set; } = 300;
        public string ShowEasing { get; set; } = "swing";
        public string OnShown { get; set; }
        public string HideMethod { get; set; } = "fadeOut";
        public int? HideDuration { get; set; } = 1000;
        public string HideEasing { get; set; } = "linear";
        public string OnHidden { get; set; }
        public bool? CloseMethod { get; set; } = false;
        public bool? CloseDuration { get; set; } = false;
        public bool? CloseEasing { get; set; } = false;
        public bool? CloseOnHover { get; set; } = true;
        public int? ExtendedTimeOut { get; set; } = 1000;
        /// <summary>
        /// Use the <see cref="IconClasses"/> to set the available values
        /// </summary>
        public string IconClass { get; set; } = IconClasses.Info;
        /// <summary>
        /// Use the <see cref="ToastPositions"/> to set the available values
        /// </summary>
        public string PositionClass { get; set; } = ToastPositions.TopRight;
        public int? TimeOut { get; set; } = 5000;
        public string TitleClass { get; set; } = "toast-title";
        public string MessageClass { get; set; } = "toast-title";
        public bool? EscapeHtml { get; set; } = false;
        public string Target { get; set; } = "body";
        public string CloseHtml { get; set; } = "<button type='button'>&times;</button>";
        public string CloseClass { get; set; } = "toast-close-button";
        public bool? NewestOnTop { get; set; } = true;
        public bool? PreventDuplicates { get; set; } = false;
        public bool? ProgressBar { get; set; } = true;
        public bool? Rtl { get; set; } = false;
        public bool? CloseButton { get; set; } = true;
        public string Onclick { get; set; }

        // Default message and title options
        public string SuccessTitle { get; set; } = "Success";
        public string SuccessMessage { get; set; } = "Task completed successfully";

        public string InfoTitle { get; set; } = "Info";

        public string WarningTitle { get; set; } = "Success";

        public string ErrorTitle { get; set; } = "Error";
        public string ErrorMessage { get; set; } = "Task could not complete successfully";

        public string Json => this.ToJson();

    }
}
