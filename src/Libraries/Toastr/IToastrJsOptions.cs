namespace NToastNotify.Libraries
{
    /// <summary>
    /// Purely mirrors the options object used by toastr.js library
    /// </summary>
    interface IToastrJsOptions
    {
        bool? TapToDismiss { get; set; }
        string ToastClass { get; set; }
        string ContainerId { get; set; }
        bool? Debug { get; set; }
        string ShowMethod { get; set; }
        int? ShowDuration { get; set; }
        string ShowEasing { get; set; }
        string OnShown { get; set; }
        string HideMethod { get; set; }
        int? HideDuration { get; set; }
        string HideEasing { get; set; }
        string OnHidden { get; set; }
        bool? CloseMethod { get; set; }
        bool? CloseDuration { get; set; }
        bool? CloseEasing { get; set; }
        bool? CloseOnHover { get; set; }
        int? ExtendedTimeOut { get; set; }
        /// <summary>
        /// Use the <see cref="IconClasses"/> to set the available values
        /// </summary>
        string IconClass { get; set; }
        /// <summary>
        /// Use the <see cref="ToastPositions"/> to set the available values
        /// </summary>
        string PositionClass { get; set; }
        int? TimeOut { get; set; }
        string TitleClass { get; set; }
        string MessageClass { get; set; }
        bool? EscapeHtml { get; set; }
        string Target { get; set; }
        string CloseHtml { get; set; }
        string CloseClass { get; set; }
        bool? NewestOnTop { get; set; }
        bool? PreventDuplicates { get; set; }
        bool? ProgressBar { get; set; }
        bool? Rtl { get; set; }
        bool? CloseButton { get; set; }
        string Onclick { get; set; }

    }
}
