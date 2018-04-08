namespace NToastNotify
{
    /// <summary>
    /// This class is used to provide options that are used by the entire library not by th third party js library.
    /// </summary>
    public class NToastNotifyOption
    {
        /// <summary>
        /// Default success title to all toast messages
        /// </summary>
        public string DefaultSuccessTitle { get; set; } = "Success";
        /// <summary>
        /// Default success message to all toast messages
        /// </summary>
        public string DefaultSuccessMessage { get; set; } = "Task completed successfully.";

        /// <summary>
        /// Default info title to all toast messages
        /// </summary>
        public string DefaultInfoTitle { get; set; } = "Info";
        /// <summary>
        /// Default info message to all toast messages
        /// </summary>
        public string DefaultInfoMessage { get; set; } = "This is an information notification.";

        /// <summary>
        /// Default warning title to all toast messages
        /// </summary>
        public string DefaultWarningTitle { get; set; } = "Warning";
        /// <summary>
        /// Default warning message to all toast messages
        /// </summary>
        public string DefaultWarningMessage { get; set; } = "This is a warning notification.";

        /// <summary>
        /// Default error title to all toast messages
        /// </summary>
        public string DefaultErrorTitle { get; set; } = "Error";
        /// <summary>
        /// Default error message to all toast messages
        /// </summary>
        public string DefaultErrorMessage { get; set; } = "Task could not complete successfully.";

        /// <summary>
        /// Default alert title to all toast messages. Not applicable if using toastr.js library
        /// </summary>
        public string DefaultAlertTitle { get; set; } = "Alert";
        /// <summary>
        /// Default alert message to all toast messages. Not applicable if using toastr.js library
        /// </summary>
        public string DefaultAlertMessage { get; set; } = "This is an alert.";

        public string VarName { get; }

        public string ScriptSrc { get; set; }
        public string StyleHref { get; set; }
    }
}
