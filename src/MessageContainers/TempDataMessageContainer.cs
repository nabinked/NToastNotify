using System.Collections.Generic;
using System.Linq;

namespace NToastNotify
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
            var messages = _tempDataWrapper.Get<IList<TMessage>>(Key) ?? new List<TMessage>();
            messages.Add(message);
            _tempDataWrapper.Add(Key, messages);

        }

        public void RemoveAll()
        {
            _tempDataWrapper.Remove(Key);
        }

        public IEnumerable<TMessage> GetAll()
        {
            return _tempDataWrapper.Peek<IList<TMessage>>(Key);
        }

        public IEnumerable<TMessage> ReadAll()
        {
            var messages = GetAll();
            RemoveAll();
            return messages;
        }
    }
}