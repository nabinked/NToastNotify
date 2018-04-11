using Microsoft.AspNetCore.Http;
using NToastNotify.Helpers;

namespace NToastNotify.MessageContainers
{
    internal class MessageContainerFactory : IMessageContainerFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataWrapper _tempDataWrapper;
        private readonly NToastNotifyOption _nToastNotifyOption;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataWrapper tempDataWrapper, NToastNotifyOption nToastNotifyOption)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
            _nToastNotifyOption = nToastNotifyOption;
        }

        public IMessageContainer<TMessage> Create<TMessage>()
            where TMessage : class, IToastMessage
        {
            if (_httpContextAccessor.HttpContext.Request.IsNtoastNotifyAjaxRequest())
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