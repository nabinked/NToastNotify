using NToastNotify.Helpers;
using NToastNotify.MessageContainers;
using static NToastNotify.Enums;

namespace NToastNotify
{
    public class GenericNotification<TOption> : ToastNotification<GenericMessage<TOption>, TOption> where TOption : GenericOptions, new()
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public GenericNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions) : base(messageContainerFactory)
        {
            _defaultNtoastNotifyOptions = nToastNotifyOptions;
        }

        public override void AddInfoToastMessage(string? message = null, TOption? GenericOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsGeneric<TOption>(GenericOptions, NotificationTypesGeneric.Info);
            var toastMessage = new GenericMessage<TOption>(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddWarningToastMessage(string? message = null, TOption? GenericOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsGeneric<TOption>(GenericOptions, NotificationTypesGeneric.Warning);
            var toastMessage = new GenericMessage<TOption>(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddErrorToastMessage(string? message = null, TOption? GenericOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsGeneric<TOption>(GenericOptions, NotificationTypesGeneric.Error);
            var toastMessage = new GenericMessage<TOption>(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddAlertToastMessage(string? message = null, TOption? GenericOptions = null)
        {
            AddInfoToastMessage(message, GenericOptions);
        }
        public override void AddSuccessToastMessage(string? message = null, TOption? GenericOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsGeneric<TOption>(GenericOptions, NotificationTypesGeneric.Success);
            var toastMessage = new GenericMessage<TOption>(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, options);
            AddMessage(toastMessage);
        }

    }
}
