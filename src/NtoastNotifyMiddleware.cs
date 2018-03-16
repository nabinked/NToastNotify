using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NToastNotify.Helpers;
using NToastNotify.Libraries;
using NToastNotify.MessageContainers;

namespace NToastNotify
{
    internal class NtoastNotifyMiddleware : IMiddleware
    {
        private readonly IToastMessagesAccessor<IToastMessage<ILibraryOptions>> _messagesAccessor;
        private readonly ILogger<NtoastNotifyMiddleware> _logger;

        public NtoastNotifyMiddleware(IToastMessagesAccessor<IToastMessage<ILibraryOptions>> messagesAccessor, ILogger<NtoastNotifyMiddleware> logger)
        {
            _messagesAccessor = messagesAccessor;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            context.Response.OnStarting(Callback, context);
            await next(context);
        }

        private Task Callback(object context)
        {
            var httpContext = (HttpContext)context;
            if (httpContext.Request.IsAjaxRequest())
            {
                var messages = _messagesAccessor.ToastMessages;
                if (messages.Any())
                {
                    httpContext.Response.Headers.Add(Constants.ResponseHeaderKey, messages.ToJson());
                }
            }
            return Task.FromResult(0);
        }

    }
}
