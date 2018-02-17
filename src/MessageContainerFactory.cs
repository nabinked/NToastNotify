using Microsoft.AspNetCore.Http;
using NToastNotify.Helpers;

namespace NToastNotify
{
    public class MessageContainerFactory<TMessage> : IMessageContainerFactory<TMessage> where TMessage : IToastMessage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataWrapper _tempDataWrapper;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataWrapper tempDataWrapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
        }
        public IMessageContainer<TMessage> Create()
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