using System.Collections.Generic;
using NToastNotify.Libraries;

namespace NToastNotify.MessageContainers
{
    public class InMemoryMessageContainer<TMessage> : IMessageContainer<TMessage> where TMessage : class, IToastMessage<ILibraryOptions>
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