namespace NToastNotify.Libraries
{
    public class DefaultOptions
    {
        public static ToastrOptions Toastr => new ToastrOptions()
        {
            TapToDismiss = true,
            ToastClass = "toast",
            ContainerId = "toast-container",
            Debug = false,
            ShowMethod = "fadeIn",
            ShowDuration = 300,
            ShowEasing = "swing",
            HideMethod = "fadeOut",
            HideDuration = 1000,
            HideEasing = "linear",
            CloseMethod = false,
            CloseDuration = false,
            CloseEasing = false,
            CloseOnHover = true,
            ExtendedTimeOut = 1000,
            IconClass = IconClasses.Info,
            PositionClass = ToastPositions.TopRight,
            TimeOut = 5000,
            TitleClass = "toast-title",
            MessageClass = "toast-message",
            EscapeHtml = false,
            Target = "body",
            CloseHtml = "<button type='button'>&times;</button>",
            CloseClass = "toast-close-button",
            NewestOnTop = true,
            PreventDuplicates = false,
            ProgressBar = true,
            Rtl = false,
            CloseButton = true,
            SuccessTitle = "Success",
            SuccessMessage = "Task completed successfully",
            InfoTitle = "Info",
            WarningTitle = "Warning",
            ErrorTitle = "Error",
            ErrorMessage = "Task could not complete successfully"
        };
        public static NotyOptions Noty => new NotyOptions()
        {
            Type = Enums.NotificationTypesNoty.Alert,
            Layout = "topRight",
            Theme = "mint",
            Timeout = 0,
            ProgressBar = true,
            CloseWith = new[] { "click" },
            Modal = false,
            Force = false,
            Queue = "global",
            VisibilityControl = false
        };
    }
}

