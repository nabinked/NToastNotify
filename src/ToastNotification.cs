using NToastNotify.Libraries;
using System.Collections.Generic;

namespace NToastNotify
{
    public abstract class ToastNotification : IToastNotification
    {
        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;
        private readonly IMessageContainer<IToastMessage> _messageContainer;

        /// <summary>
        /// Toast notification constructor
        /// </summary>
        /// <param name="messageContainerFactory"></param>
        /// <param name="nToastNotifyOptions">Default toast notify options</param>
        public ToastNotification(IMessageContainerFactory<IToastMessage> messageContainerFactory, NToastNotifyOption nToastNotifyOptions)
        {
            _messageContainer = messageContainerFactory.Create();
            _defaultNtoastNotifyOptions = nToastNotifyOptions.MergeWith(new NToastNotifyOption());
        }

        public void AddSuccessToastMessage(string message = null, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultSuccessMessage, title ?? _defaultNtoastNotifyOptions.DefaultSuccessTitle, Enums.NotificationTypesToastr.Success, toasILibraryOptions);
            AddMessage(toastMessage);
        }

        public void AddInfoToastMessage(string message, string title = null, ILibraryOptions toasILibraryOptions = null)
        {
            var toastMessage = new ToastrMessage(message ?? _defaultNtoastNotifyOptions.DefaultInfoMessage, title ?? _defaultNtoastNotifyOptions.DefaultInfoTitle, Enums.NotificationTypesToastr.Info, toasILibraryOptions);
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


        public IEnumerable<IToastMessage> GetToastMessages()
        {
            return _messageContainer.GetAll();
        }

        public IEnumerable<IToastMessage> ReadAllMessages()
        {
            return _messageContainer.ReadAll();
        }

        public void RemoveAll()
        {
            _messageContainer.RemoveAll();
        }

        protected void AddMessage(IToastMessage toastMessage)
        {
            _messageContainer.Add(toastMessage);
        }

    }
}
