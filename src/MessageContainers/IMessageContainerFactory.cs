using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify
{
    public interface IMessageContainerFactory<TMessage> where TMessage : class, IToastMessage
    {
        IMessageContainer<TMessage> Create();
    }
}
