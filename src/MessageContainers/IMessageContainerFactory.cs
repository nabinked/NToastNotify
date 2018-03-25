using NToastNotify.Helpers;

namespace NToastNotify.MessageContainers
{
    public interface IMessageContainerFactory
    {
        IMessageContainer<TMessage> Create<TMessage>() where TMessage : class, IToastMessage;
    }
}
