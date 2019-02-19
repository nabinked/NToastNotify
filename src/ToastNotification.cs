using System.Collections.Generic;
using NToastNotify.Helpers;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    public abstract class ToastNotification<TMessage, TOptions> : IToastNotification
        where TMessage : class, IToastMessage
        where TOptions : class, ILibraryOptions, new()
    {
        private readonly IMessageContainerFactory _messageContainerFactory;
        protected IMessageContainer<TMessage> MessageContainer;

        protected ToastNotification(IMessageContainerFactory messageContainerFactory)
        {
            _messageContainerFactory = messageContainerFactory;
        }
        public abstract void AddAlertToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddErrorToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddInfoToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddSuccessToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public abstract void AddWarningToastMessage(string message = null, ILibraryOptions toastOptions = null);
        public IEnumerable<IToastMessage> GetToastMessages()
        {
            return MessageContainer?.GetAll() ?? new List<TMessage>(); ;
        }

        public IEnumerable<IToastMessage> ReadAllMessages()
        {
            return MessageContainer?.ReadAll() ?? new List<TMessage>(); ;
        }

        public void RemoveAll()
        {
            MessageContainer?.RemoveAll();
        }

        protected void AddMessage(TMessage toastMessage)
        {
            OptionsHelpers.EnsureSameType<TOptions>(toastMessage.Options);
            InitializeMessageContainer();
            MessageContainer.Add(toastMessage);
        }

        private void InitializeMessageContainer()
        {
            MessageContainer = MessageContainer ?? _messageContainerFactory.Create<TMessage>();
        }
    }
}
