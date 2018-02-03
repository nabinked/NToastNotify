using System.Collections.Generic;
using System.Linq;

namespace NToastNotify
{
    public class TempDataMessageContainer : IMessageContainer
    {
        private readonly ITempDataWrapper _tempDataWrapper;
        private const string Key = "NToastNotify.Messages.TempDataKey";

        public TempDataMessageContainer(ITempDataWrapper tempDataWrapper)
        {
            _tempDataWrapper = tempDataWrapper;
        }
        public void Add(ToastMessage message)
        {
            var messages = _tempDataWrapper.Get<IList<ToastMessage>>(Key) ?? new List<ToastMessage>();
            messages.Add(message);
            _tempDataWrapper.Add(Key, messages);

        }

        public void RemoveAll()
        {
            _tempDataWrapper.Remove(Key);
        }

        public IList<ToastMessage> GetAll()
        {
            return _tempDataWrapper.Peek<IList<ToastMessage>>(Key);
        }

        public IList<ToastMessage> ReadAll()
        {
            var messages = GetAll();
            RemoveAll();
            return messages;
        }
    }
}