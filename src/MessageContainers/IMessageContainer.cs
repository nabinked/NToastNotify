using System.Collections.Generic;
using NToastNotify.Libraries;

namespace NToastNotify.MessageContainers
{
    public interface IMessageContainer<TMessage> where TMessage : class, IToastMessage<ILibraryOptions>
    {
        void Add(TMessage message);
        void RemoveAll();
        IList<TMessage> GetAll();
        IList<TMessage> ReadAll();
    }
}
