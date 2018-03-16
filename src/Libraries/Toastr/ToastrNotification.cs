using System.Collections.Generic;
using NToastNotify.MessageContainers;

namespace NToastNotify.Libraries.Toastr
{
    public class ToastrNotification : IToastNotification
    {
        private readonly IMessageContainer<ToastrMessage> _messageContainer;
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public ToastrNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions)
        {
            this._messageContainer = messageContainerFactory.Create<ToastrMessage>();
            this._defaultNtoastNotifyOptions = nToastNotifyOptions;
        }

        public void AddInfoToastMessage(string message, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? this._defaultNtoastNotifyOptions.DefaultInfoMessage, title ?? this._defaultNtoastNotifyOptions.DefaultInfoTitle, Enums.NotificationTypesToastr.Info, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public void AddWarningToastMessage(string message = null, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, title ?? _defaultNtoastNotifyOptions.DefaultWarningTitle, Enums.NotificationTypesToastr.Warning, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public void AddErrorToastMessage(string message = null, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, title ?? _defaultNtoastNotifyOptions.DefaultErrorTitle, Enums.NotificationTypesToastr.Error, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public void AddAlertToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            AddInfoToastMessage(message, title, toastOptions);
        }

        public void AddSuccessToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, title ?? _defaultNtoastNotifyOptions.DefaultSuccessTitle, Enums.NotificationTypesToastr.Success, toastOptions);
            AddMessage(toastMessage);
        }
        public IEnumerable<IToastMessage> GetToastMessages()
        {
            return this._messageContainer.GetAll();
        }

        public IEnumerable<IToastMessage> ReadAllMessages()
        {
            return this._messageContainer.ReadAll();
        }

        public void RemoveAll()
        {
            this._messageContainer.RemoveAll();
        }

        private void AddMessage(ToastrMessage toastMessage)
        {
            this._messageContainer.Add(toastMessage);
        }
    }
}
