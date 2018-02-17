using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify
{
    public interface IMessageContainer<TMessage> where TMessage : IToastMessage
    {
        void Add(TMessage message);
        void RemoveAll();
        IEnumerable<TMessage> GetAll();
        IEnumerable<TMessage> ReadAll();
    }
}
