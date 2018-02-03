using Microsoft.AspNetCore.Http;
using NToastNotify.Helpers;

namespace NToastNotify
{
    public class MessageContainerFactory : IMessageContainerFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataWrapper _tempDataWrapper;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataWrapper tempDataWrapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
        }
        public IMessageContainer Create()
        {
            if (_httpContextAccessor.HttpContext.Request.IsAjaxRequest())
            {
                return new InMemoryMessageContainer();
            }
            else
            {
                return new TempDataMessageContainer(_tempDataWrapper);
            }
        }
    }
}