using System.Collections.Generic;
using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    /*
     * TODO:
     * Find out a way so that TOptions could be used as toasOptions parameter type without breaking anything
     */
    public abstract class ToastNotification<TMessage, TOptions> : IToastNotification
        where TMessage : class, IToastMessage
        where TOptions : LibraryOptions, new()
    {
        protected IMessageContainer<TMessage> MessageContainer;

        protected ToastNotification(IMessageContainerFactory messageContainerFactory)
        {
            MessageContainer = messageContainerFactory.Create<TMessage>();
        }
        public abstract void AddAlertToastMessage(string message = null, LibraryOptions toastOptions = null);
        public abstract void AddErrorToastMessage(string message = null, LibraryOptions toastOptions = null);
        public abstract void AddInfoToastMessage(string message = null, LibraryOptions toastOptions = null);
        public abstract void AddSuccessToastMessage(string message = null, LibraryOptions toastOptions = null);
        public abstract void AddWarningToastMessage(string message = null, LibraryOptions toastOptions = null);
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
