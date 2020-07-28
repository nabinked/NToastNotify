using System.Collections.Generic;
using System.Linq;
using NToastNotify.Helpers;

namespace NToastNotify.MessageContainers
{
    public class TempDataMessageContainer<TMessage> : IMessageContainer<TMessage> where TMessage : class, IToastMessage
    {
        private readonly ITempDataWrapper _tempDataWrapper;
        private const string Key = "NToastNotify.Messages.TempDataKey";

        public TempDataMessageContainer(ITempDataWrapper tempDataWrapper)
        {
            _tempDataWrapper = tempDataWrapper;
        }
        public void Add(TMessage message)
        {
            var messages = _tempDataWrapper.Get<IEnumerable<TMessage>>(Key) ?? new List<TMessage>();
            var messagesList = messages.ToList();
            messagesList.Add(message);
            _tempDataWrapper.Add(Key, messagesList);

        }

        public void RemoveAll()
        {
            _tempDataWrapper.Remove(Key);
        }

        public IList<TMessage> GetAll()
        {
            return _tempDataWrapper.Peek<List<TMessage>>(Key) ?? new List<TMessage>();
        }

        public IList<TMessage> ReadAll()
        {
            var messages = GetAll();
            RemoveAll();
            return messages;
        }
    }
}