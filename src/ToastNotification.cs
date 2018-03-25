using System.Collections.Generic;
using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    public abstract class ToastNotification<TMessage, TOptions> : IToastNotification
        where TMessage : class, IToastMessage
        where TOptions : class, ILibraryOptions, new()
    {
        protected IMessageContainer<TMessage> _messageContainer;

        public ToastNotification(IMessageContainerFactory messageContainerFactory)
        {
            _messageContainer = messageContainerFactory.Create<TMessage>();
        }
        public abstract void AddAlertToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddErrorToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddInfoToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddSuccessToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddWarningToastMessage(string message = null, ILibraryOptions toastOptions = null);
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

        protected void AddMessage(TMessage toastMessage)
        {
            OptionsHelpers.EnsureSameType<TOptions>(toastMessage.Options);
            _messageContainer.Add(toastMessage);
        }
    }
}
