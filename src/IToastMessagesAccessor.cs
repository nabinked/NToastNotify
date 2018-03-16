using NToastNotify.Libraries;
using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastMessagesAccessor<out TMessage> where TMessage : class, IToastMessage
    {
        IEnumerable<TMessage> ToastMessages { get; }
    }
}
