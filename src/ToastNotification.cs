using System.Collections.Generic;
using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    public abstract class ToastNotification<TMessage, TOptions> : IToastNotification
        where TMessage : class, IToastMessage
        where TOptions : class, ILibraryOptions, new()
    {
        protected IMessageContainer<TMessage> MessageContainer;

        protected ToastNotification(IMessageContainerFactory messageContainerFactory)
        {
            MessageContainer = messageContainerFactory.Create<TMessage>();
        }
        public abstract void AddAlertToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddErrorToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddInfoToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddSuccessToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddWarningToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public IEnumerable<IToastMessage> GetToastMessages()
        {
            return MessageContainer.GetAll();
        }

        public IEnumerable<IToastMessage> ReadAllMessages()
        {
            return MessageContainer.ReadAll();
        }

        public void RemoveAll()
        {
            MessageContainer.RemoveAll();
        }

        protected void AddMessage(TMessage toastMessage)
        {
            OptionsHelpers.EnsureSameType<TOptions>(toastMessage.Options);
            MessageContainer.Add(toastMessage);
        }
    }
}
