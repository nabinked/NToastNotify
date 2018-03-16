using Microsoft.AspNetCore.Http;
using NToastNotify.Helpers;
using NToastNotify.Libraries;

namespace NToastNotify.MessageContainers
{
    internal class MessageContainerFactory : IMessageContainerFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataWrapper _tempDataWrapper;
        private object instance;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataWrapper tempDataWrapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
        }

        public IMessageContainer<TMessage> Create<TMessage>()
            where TMessage : class, IToastMessage<ILibraryOptions>
        {
            IMessageContainer<TMessage> i = null;
            if (_httpContextAccessor.HttpContext.Request.IsAjaxRequest())
            {
                if (instance == null)
                {
                    i = new InMemoryMessageContainer<TMessage>();
                    return i;
                }
                else
                {
                    return (IMessageContainer<TMessage>)instance;
                }
            }
            else
            {
                if (instance == null)
                {
                    i = new TempDataMessageContainer<TMessage>(_tempDataWrapper);
                    return i;
                }

                return (IMessageContainer<TMessage>)instance;
            }
        }
    }
}