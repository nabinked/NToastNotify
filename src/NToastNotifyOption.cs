using NToastNotify.Libraries;
using System;

namespace NToastNotify
{
    /// <summary>
    /// These options are related to how NToastNotify creates the toast notifications but not to their rendering
    /// These will not be rendered with the HTML and will only be used to convey default options when creating toast messages
    /// and storing
    /// TODO: Rename this class to better represent what it does???
    /// </summary>
    public class NToastNotifyOption
    {
        // Default message and title options
        [Obsolete("Use DefaultSuccessTitle", true)]
        public string SuccessTitle { get; set; }
        public string DefaultSuccessTitle { get; set; } = "Success";

        [Obsolete("Use DefaultSuccessMessage", true)]
        public string SuccessMessage { get; set; }
        public string DefaultSuccessMessage { get; set; } = "Task completed successfully.";

        [Obsolete("Use DefaultInfoTitle", true)]
        public string InfoTitle { get; set; }
        public string DefaultInfoTitle { get; set; } = "Info";

        [Obsolete("Use DefaultInfoMessage", true)]
        public string InfoMessage { get; set; }
        public string DefaultInfoMessage { get; set; } = "This is an information notification.";

        [Obsolete("Use DefaultWarningTitle", true)]
        public string WarningTitle { get; set; }
        public string DefaultWarningTitle { get; set; } = "Warning";

        [Obsolete("Use DefaultWarningMessage", true)]
        public string WarningMessage { get; set; }
        public string DefaultWarningMessage { get; set; } = "This is a warning notification.";

        [Obsolete("Use DefaultErrorTitle", true)]
        public string ErrorTitle { get; set; }
        public string DefaultErrorTitle { get; set; } = "Error";

        [Obsolete("Use DefaultErrorMessage", true)]
        public string ErrorMessage { get; set; }
        public string DefaultErrorMessage { get; set; } = "Task could not complete successfully.";

        public ILibrary LibraryDetails { get; set; }
    }
}
