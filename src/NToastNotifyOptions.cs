namespace NToastNotify
{
    /// <summary>
    /// These options are related to how NToastNotify creates the toast notifications but not to their rendering
    /// These will not be rendered with the HTML and will only be used to convey default options when creating toast messages
    /// and storing them in the TempData
    /// TODO: Rename this class to better represent what it does???
    /// </summary>
    public class NToastNotifyOptions
    {
        // Default message and title options
        public string SuccessTitle { get; set; }
        public string SuccessMessage { get; set; }

        public string InfoTitle { get; set; }
        public string InfoMessage { get; set; }

        public string WarningTitle { get; set; }
        public string WarningMessage { get; set; }

        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }

        public static NToastNotifyOptions Defaults => new NToastNotifyOptions()
        {
            SuccessTitle = "Success",
            SuccessMessage = "Task completed successfully",
            InfoTitle = "Info",
            InfoMessage = "This is an information notification",
            WarningTitle = "Warning",
            WarningMessage = "This is a warning notification",
            ErrorTitle = "Error",
            ErrorMessage = "Task could not complete successfully"
        };
    }
}
