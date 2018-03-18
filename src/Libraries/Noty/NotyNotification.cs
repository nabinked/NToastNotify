using NToastNotify.MessageContainers;

namespace NToastNotify.Libraries
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
            var notyOptions = OptionsCaster.CastOptionTo<NotyOptions>(toastOptions);
            notyOptions.Type = Enums.NotificationTypesNoty.Success;
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, notyOptions);
            AddMessage(successNotyMessage);
        }

        public override void AddInfoToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var notyOptions = OptionsCaster.CastOptionTo<NotyOptions>(toastOptions);
            notyOptions.Type = Enums.NotificationTypesNoty.Info;
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, notyOptions);
            AddMessage(successNotyMessage);
        }

        public override void AddAlertToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var notyOptions = OptionsCaster.CastOptionTo<NotyOptions>(toastOptions);
            notyOptions.Type = Enums.NotificationTypesNoty.Alert;
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultAlertMessage, notyOptions);
            AddMessage(successNotyMessage);
        }

        public override void AddWarningToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var notyOptions = OptionsCaster.CastOptionTo<NotyOptions>(toastOptions);
            notyOptions.Type = Enums.NotificationTypesNoty.Warning;
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningTitle, notyOptions);
            AddMessage(successNotyMessage);
        }

        public override void AddErrorToastMessage(string message = null, ILibraryOptions toastOptions = null)
        {
            var notyOptions = OptionsCaster.CastOptionTo<NotyOptions>(toastOptions);
            notyOptions.Type = Enums.NotificationTypesNoty.Error;
            var successNotyMessage = new NotyMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, notyOptions);
            AddMessage(successNotyMessage);
        }

        private void InitToastOptions(NotyOptions notyOptions, string message, Enums.NotificationTypesNoty notificationTypes)
        {
            notyOptions.Text = message;
            notyOptions.Type = notificationTypes;
        }
    }
}
