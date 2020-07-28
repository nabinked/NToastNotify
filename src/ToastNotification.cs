using System.Collections.Generic;
using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    public abstract class ToastNotification<TMessage, TOptions> : IToastNotification
        where TMessage : class, IToastMessage
        where TOptions : LibraryOptions, new()
    {
        protected IMessageContainer<TMessage> MessageContainer;

        protected ToastNotification(IMessageContainerFactory messageContainerFactory)
        {
            MessageContainer = messageContainerFactory.Create<TMessage>();
        }
        void IToastNotification.AddAlertToastMessage(string? message, LibraryOptions? toastOptions)
        {
            AddAlertToastMessage(message, toastOptions as TOptions);
        }
        void IToastNotification.AddErrorToastMessage(string? message, LibraryOptions? toastOptions)
        {
            AddErrorToastMessage(message, toastOptions as TOptions);
        }
        void IToastNotification.AddInfoToastMessage(string? message, LibraryOptions? toastOptions)
        {
            AddInfoToastMessage(message, toastOptions as TOptions);
        }
        void IToastNotification.AddSuccessToastMessage(string? message, LibraryOptions? toastOptions)
        {
            AddSuccessToastMessage(message, toastOptions as TOptions);
        }
        void IToastNotification.AddWarningToastMessage(string? message, LibraryOptions? toastOptions)
        {
            AddWarningToastMessage(message, toastOptions as TOptions);
        }

        public abstract void AddAlertToastMessage(string? message = null, TOptions? toastOptions = null);
        public abstract void AddErrorToastMessage(string? message = null, TOptions? toastOptions = null);
        public abstract void AddInfoToastMessage(string? message = null, TOptions? toastOptions = null);
        public abstract void AddSuccessToastMessage(string? message = null, TOptions? toastOptions = null);
        public abstract void AddWarningToastMessage(string? message = null, TOptions? toastOptions = null);
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
