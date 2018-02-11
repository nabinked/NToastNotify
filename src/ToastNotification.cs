using System.Collections.Generic;

namespace NToastNotify
{
    public class ToastNotification : IToastNotification
    {

        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;
        private readonly IMessageContainer _messageContainer;

        /// <summary>
        /// Toast notification constructor
        /// </summary>
        /// <param name="messageContainerFactory"></param>
        /// <param name="nToastNotifyOptions">Default toast notify options</param>
        public ToastNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions)
        {
            _messageContainer = messageContainerFactory.Create();
            _defaultNtoastNotifyOptions = nToastNotifyOptions.MergeWith(NToastNotifyOption.Defaults);
        }

        public void AddToastMessage(string title, string message, Enums.ToastType notificationType)
        {
            var toastMessage = new ToastMessage(message, title, notificationType);
            AddMessage(toastMessage);
        }
        public void AddToastMessage(string title, string message, Enums.ToastType notificationType, Option toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, notificationType, toastOptions);
            AddMessage(toastMessage);
        }


        public void AddSuccessToastMessage(string message = null, string title = null, Option toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.SuccessMessage, title ?? _defaultNtoastNotifyOptions.SuccessTitle, Enums.ToastType.Success, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddInfoToastMessage(string message, string title = null, Option toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.InfoMessage, title ?? _defaultNtoastNotifyOptions.InfoTitle, Enums.ToastType.Info, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddWarningToastMessage(string message = null, string title = null, Option toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.WarningMessage, title ?? _defaultNtoastNotifyOptions.WarningTitle, Enums.ToastType.Warning, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddErrorToastMessage(string message = null, string title = null, Option toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.ErrorMessage, title ?? _defaultNtoastNotifyOptions.ErrorTitle, Enums.ToastType.Error, toastOptions);
            AddMessage(toastMessage);
        }


        public IEnumerable<ToastMessage> GetToastMessages()
        {
            return _messageContainer.GetAll();
        }

        public IEnumerable<ToastMessage> ReadAllMessages()
        {
            return _messageContainer.ReadAll();
        }

        public void RemoveAll()
        {
            _messageContainer.RemoveAll();
        }

        #region Privates
        private void AddMessage(ToastMessage toastMessage)
        {
            _messageContainer.Add(toastMessage);
        }

        #endregion
    }
}
