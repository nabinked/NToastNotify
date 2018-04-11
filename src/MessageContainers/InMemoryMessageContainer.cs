using System.Collections.Generic;

namespace NToastNotify.MessageContainers
{
    /// <summary>
    /// This container is used for ajax calls.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public class InMemoryMessageContainer<TMessage> : IMessageContainer<TMessage> where TMessage : class, IToastMessage
    {
        private IList<TMessage> Messages { get; }

        public InMemoryMessageContainer()
        {
            Messages = new List<TMessage>();
        }
        public void Add(TMessage message)
        {
            Messages.Add(message);
        }

        public void RemoveAll()
        {
            Messages.Clear();
        }

        public IList<TMessage> GetAll()
        {
            return Messages;
        }

        public IList<TMessage> ReadAll()
        {
            var messages = new List<TMessage>(Messages);
            Messages.Clear();
            return messages;
        }
    }
}