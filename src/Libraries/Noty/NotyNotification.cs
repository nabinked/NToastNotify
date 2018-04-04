using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    public class NotyNotification : ToastNotification<NotyMessage, NotyOptions>
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public NotyNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions) : base(messageContainerFactory)
        {
            _defaultNtoastNotifyOptions = nToastNotifyOptions;
        }
        public override void AddSuccessToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsNoty(toastOptions, message, Enums.NotificationTypesNoty.Success);
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, options);
            AddMessage(successNotyMessage);
        }

        public override void AddInfoToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsNoty(toastOptions, message, Enums.NotificationTypesNoty.Info);
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, options);
            AddMessage(successNotyMessage);
        }

        public override void AddAlertToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsNoty(toastOptions, message, Enums.NotificationTypesNoty.Alert);
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultAlertMessage, options);
            AddMessage(successNotyMessage);
        }

        public override void AddWarningToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsNoty(toastOptions, message, Enums.NotificationTypesNoty.Warning);
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningTitle, options);
            AddMessage(successNotyMessage);
        }

        public override void AddErrorToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsNoty(toastOptions, message, Enums.NotificationTypesNoty.Error);
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, options);
            AddMessage(successNotyMessage);
        }
    }
}
