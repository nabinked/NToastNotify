using System.Collections.Generic;
using System.Linq;

namespace NToastNotify
{
    public class InMemoryMessageContainer<TMessage> : IMessageContainer<TMessage> where TMessage : IToastMessage
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