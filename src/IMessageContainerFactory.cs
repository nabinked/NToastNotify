using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify
{
    public interface IMessageContainerFactory<out TMessage> where TMessage : IToastMessage
    {
        IMessageContainer<TMessage> Create();
    }
}
