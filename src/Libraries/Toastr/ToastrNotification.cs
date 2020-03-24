using NToastNotify.Helpers;
using NToastNotify.MessageContainers;
using static NToastNotify.Enums;

namespace NToastNotify
{
    public class ToastrNotification : ToastNotification<ToastrMessage, ToastrOptions>
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public ToastrNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions) : base(messageContainerFactory)
        {
            _defaultNtoastNotifyOptions = nToastNotifyOptions;
        }

        public override void AddInfoToastMessage(string message = null, ToastrOptions toastrOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsToastr(toastrOptions, NotificationTypesToastr.Info, _defaultNtoastNotifyOptions.DefaultInfoTitle);
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddWarningToastMessage(string message = null, ToastrOptions toastrOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsToastr(toastrOptions, NotificationTypesToastr.Warning, _defaultNtoastNotifyOptions.DefaultWarningTitle);
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddErrorToastMessage(string message = null, ToastrOptions toastrOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsToastr(toastrOptions, NotificationTypesToastr.Error, _defaultNtoastNotifyOptions.DefaultErrorTitle);
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, options);
            AddMessage(toastMessage);
        }
        public override void AddAlertToastMessage(string message = null, ToastrOptions toastrOptions = null)
        {
            //because toastr js does not have an alert type.
            AddInfoToastMessage(message, toastrOptions);
        }
        public override void AddSuccessToastMessage(string message = null, ToastrOptions toastrOptions = null)
        {
            var options = OptionsHelpers.PrepareOptionsToastr(toastrOptions, NotificationTypesToastr.Success, _defaultNtoastNotifyOptions.DefaultSuccessTitle);
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, options);
            AddMessage(toastMessage);
        }

    }
}
