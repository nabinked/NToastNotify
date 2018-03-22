using NToastNotify.MessageContainers;

namespace NToastNotify.Libraries
{
    public class ToastrNotification : ToastNotification<ToastrMessage, IToastrJsOptions>
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public ToastrNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions) : base(messageContainerFactory)
        {
            _defaultNtoastNotifyOptions = nToastNotifyOptions;
        }

        public override void AddInfoToastMessage(string message, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, _defaultNtoastNotifyOptions.DefaultInfoTitle, Enums.NotificationTypesToastr.Info, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public override void AddWarningToastMessage(string message = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, _defaultNtoastNotifyOptions.DefaultWarningTitle, Enums.NotificationTypesToastr.Warning, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public override void AddErrorToastMessage(string message = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, _defaultNtoastNotifyOptions.DefaultErrorTitle, Enums.NotificationTypesToastr.Error, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public override void AddAlertToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            //because toastr js does not have an alert type.
            AddInfoToastMessage(message, toastOptions);
        }

        public override void AddSuccessToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, _defaultNtoastNotifyOptions.DefaultSuccessTitle, Enums.NotificationTypesToastr.Success, toastOptions);
            AddMessage(toastMessage);
        }

    }
}
