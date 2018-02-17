using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify
{
    public interface IMessageContainer<out TMessage> where TMessage : IToastMessage
    {
        void Add(TMessage message);
        void RemoveAll();
        IEnumerable<TMessage> GetAll();
        IEnumerable<TMessage> ReadAll();
    }
}
