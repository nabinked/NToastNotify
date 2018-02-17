using Microsoft.AspNetCore.Http;
using NToastNotify.Helpers;

namespace NToastNotify
{
    public class MessageContainerFactory<TMesssage> : IMessageContainerFactory<TMesssage> where TMesssage : class, IToastMessage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataWrapper _tempDataWrapper;

        public MessageContainerFactory(IHttpContextAccessor httpContextAccessor, ITempDataWrapper tempDataWrapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataWrapper = tempDataWrapper;
        }
        public IMessageContainer<TMesssage> Create()
        {
            if (_httpContextAccessor.HttpContext.Request.IsAjaxRequest())
            {
                return new InMemoryMessageContainer<TMesssage>();
            }
            else
            {
                return new TempDataMessageContainer<TMesssage>(_tempDataWrapper);
            }
        }
    }
}