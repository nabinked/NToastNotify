using NToastNotify.Helpers;
using NToastNotify.MessageContainers;
using static NToastNotify.Enums;

namespace NToastNotify
{
    public class BootstrapNotification : ToastNotification<BootstrapMessage, BootstrapOptions>
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;
        private readonly BootstrapOptions? _defaultBootstrapOptions;

        public BootstrapNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions, ILibrary library) : base(messageContainerFactory)
        {
            _defaultNtoastNotifyOptions = nToastNotifyOptions;
            _defaultBootstrapOptions = library.Options as BootstrapOptions;
        }

        public override void AddInfoToastMessage(string? message = null, BootstrapOptions? bootstrapOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsBootstrap(bootstrapOptions ?? _defaultBootstrapOptions, NotificationTypesBootstrap.Info);
            var toastMessage = new BootstrapMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddWarningToastMessage(string? message = null, BootstrapOptions? bootstrapOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsBootstrap(bootstrapOptions ?? _defaultBootstrapOptions, NotificationTypesBootstrap.Warning);
            var toastMessage = new BootstrapMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddErrorToastMessage(string? message = null, BootstrapOptions? bootstrapOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsBootstrap(bootstrapOptions ?? _defaultBootstrapOptions, NotificationTypesBootstrap.Danger);
            var toastMessage = new BootstrapMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddAlertToastMessage(string? message = null, BootstrapOptions? bootstrapOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsBootstrap(bootstrapOptions ?? _defaultBootstrapOptions, NotificationTypesBootstrap.Primary);
            var toastMessage = new BootstrapMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddSuccessToastMessage(string? message = null, BootstrapOptions? bootstrapOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsBootstrap(bootstrapOptions ?? _defaultBootstrapOptions, NotificationTypesBootstrap.Success);
            var toastMessage = new BootstrapMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, options);
            AddMessage(toastMessage);
        }

    }
}
