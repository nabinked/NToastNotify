using System.Collections.Generic;
using System.Linq;

namespace NToastNotify
{
    public class InMemoryMessageContainer : IMessageContainer
    {
        private IList<ToastMessage> Messages { get; }

        public InMemoryMessageContainer()
        {
            Messages = new List<ToastMessage>();
        }
        public void Add(ToastMessage message)
        {
            Messages.Add(message);
        }

        public void RemoveAll()
        {
            Messages.Clear();
        }

        public IList<ToastMessage> GetAll()
        {
            return Messages;
        }

        public IList<ToastMessage> ReadAll()
        {
            var messages = new List<ToastMessage>(Messages);
            Messages.Clear();
            return messages;
        }
    }
}