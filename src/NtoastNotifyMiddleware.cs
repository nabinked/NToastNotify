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
        private readonly IToastNotification _toastNotification;
        private readonly ILogger<NtoastNotifyMiddleware> _logger;
        private const string AccessControlExposeHeadersKey = "Access-Control-Expose-Headers";
        public NtoastNotifyMiddleware(IToastNotification toastNotification, ILogger<NtoastNotifyMiddleware> logger)
        {
            _toastNotification = toastNotification;
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
                var messages = _toastNotification.ReadAllMessages();
                if (messages != null && messages.Any())
                {
                    httpContext.Response.Headers.Add(AccessControlExposeHeadersKey, $"{GetControlExposeHeaders(httpContext.Response.Headers)}");
                    httpContext.Response.Headers.Add(Constants.ResponseHeaderKey, messages.ToJson());
                }
            }
            return Task.FromResult(0);
        }

        private object GetControlExposeHeaders(IHeaderDictionary headers)
        {
            var existingHeaders = headers[AccessControlExposeHeadersKey];
            if (string.IsNullOrEmpty(existingHeaders))
            {
                return Constants.ResponseHeaderKey;
            }
            else
            {
                return $"{existingHeaders}, {Constants.ResponseHeaderKey}";
            }
        }
    }
}
