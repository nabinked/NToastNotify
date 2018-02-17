using System.Collections.Generic;
using System.Linq;

namespace NToastNotify
{
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

        public IEnumerable<TMessage> GetAll()
        {
            return Messages;
        }

        public IEnumerable<TMessage> ReadAll()
        {
            var messages = new List<TMessage>(Messages);
            Messages.Clear();
            return messages;
        }
    }
}