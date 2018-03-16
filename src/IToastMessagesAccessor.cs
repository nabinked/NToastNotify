using System;
using System.Collections.Generic;
using System.Text;
using NToastNotify.Libraries;

namespace NToastNotify
{
    public interface IToastMessagesAccessor<out TMessage> where TMessage : class, IToastMessage<ILibraryOptions>
    {
        IEnumerable<TMessage> ToastMessages { get; }
    }
}
