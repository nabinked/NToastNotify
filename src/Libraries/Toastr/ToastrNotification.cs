using NToastNotify.MessageContainers;

namespace NToastNotify.Libraries
{
    public class ToastrNotification : ToastNotification<ToastrMessage, ToastrOptions>
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public ToastrNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions) : base(messageContainerFactory)
        {
            _defaultNtoastNotifyOptions = nToastNotifyOptions;
        }

        public override void AddInfoToastMessage(string message, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, title ?? _defaultNtoastNotifyOptions.DefaultInfoTitle, Enums.NotificationTypesToastr.Info, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public override void AddWarningToastMessage(string message = null, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, title ?? _defaultNtoastNotifyOptions.DefaultWarningTitle, Enums.NotificationTypesToastr.Warning, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public override void AddErrorToastMessage(string message = null, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, title ?? _defaultNtoastNotifyOptions.DefaultErrorTitle, Enums.NotificationTypesToastr.Error, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public override void AddAlertToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            AddInfoToastMessage(message, title, toastOptions);
        }

        public override void AddSuccessToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, title ??
                                                _defaultNtoastNotifyOptions.DefaultSuccessTitle,
                                                Enums.NotificationTypesToastr.Success, toastOptions);
            AddMessage(toastMessage);
        }

    }
}
