using System;
using System.Collections.Generic;
using System.Text;
using NToastNotify.MessageContainers;

namespace NToastNotify.Libraries.Toastr
{
    public class ToastrNotification : IToastrNotification
    {
        private readonly IMessageContainer<ToastrMessage> _messageContainer;
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;

        public ToastrNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions)
        {
            this._messageContainer = messageContainerFactory.Create<ToastrMessage>();
            this._defaultNtoastNotifyOptions = nToastNotifyOptions;
        }

        public void AddToastMessage(string title, string message, Enums.NotificationTypesToastr notificationType)
        {
            var toastMessage = new ToastrMessage(message, title, notificationType);
            AddMessage(toastMessage);
        }

        public void AddToastMessage(string title, string message, Enums.NotificationTypesToastr notificationType, ToastrOptions toasILibraryOptions)
        {
            var toastMessage = new ToastrMessage(message, title, notificationType, toasILibraryOptions);
            AddMessage(toastMessage);
        }
        public void AddInfoToastMessage(string message, string title = null, ToastrOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? this._defaultNtoastNotifyOptions.DefaultInfoMessage, title ?? this._defaultNtoastNotifyOptions.DefaultInfoTitle, Enums.NotificationTypesToastr.Info, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public void AddWarningToastMessage(string message = null, string title = null, ToastrOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultWarningMessage, title ?? _defaultNtoastNotifyOptions.DefaultWarningTitle, Enums.NotificationTypesToastr.Warning, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public void AddErrorToastMessage(string message = null, string title = null, ToastrOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultErrorMessage, title ?? _defaultNtoastNotifyOptions.DefaultErrorTitle, Enums.NotificationTypesToastr.Error, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public IEnumerable<ToastrMessage> GetToastMessages()
        {
            return this._messageContainer.GetAll();
        }

        public IEnumerable<ToastrMessage> ReadAllMessages()
        {
            return this._messageContainer.ReadAll();
        }

        public void AddSuccessToastMessage(string message = null, string title = null, ToastrOptions toastOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, title ?? _defaultNtoastNotifyOptions.DefaultSuccessTitle, Enums.NotificationTypesToastr.Success, toastOptions);
            AddMessage(toastMessage);
        }

        public void RemoveAll()
        {
            this._messageContainer.RemoveAll();
        }

        protected void AddMessage(ToastrMessage toastMessage)
        {
            this._messageContainer.Add(toastMessage);
        }
    }
}
