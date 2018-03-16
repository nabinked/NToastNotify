using System.Collections.Generic;
using NToastNotify.Libraries;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    public class ToastMessagesAccessor<TMessage> : IToastMessagesAccessor<TMessage> where TMessage : class, IToastMessage
    {
        /// <summary>
        /// this does a destroy read from the message container.
        /// </summary>
        /// <param name="messageContainer"></param>
        public ToastMessagesAccessor(IMessageContainerFactory messageContainer)
        {
            ToastMessages = messageContainer.Create<TMessage>().ReadAll();
        }
        public IEnumerable<TMessage> ToastMessages { get; }
    }
}