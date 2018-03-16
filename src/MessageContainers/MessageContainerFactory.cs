using Microsoft.AspNetCore.Http;
using NToastNotify.Helpers;
using NToastNotify.Libraries;

namespace NToastNotify.MessageContainers
{
    internal class MessageContainerFactory : IMessageContainerFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataWrapper _tempDataWrapper;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataWrapper tempDataWrapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
        }

        public IMessageContainer<TMessage> Create<TMessage>()
            where TMessage : class, IToastMessage
        {
            if (_httpContextAccessor.HttpContext.Request.IsAjaxRequest())
            {
                return new InMemoryMessageContainer<TMessage>();
            }
            else
            {
                return new TempDataMessageContainer<TMessage>(_tempDataWrapper);
            }
        }
    }
}