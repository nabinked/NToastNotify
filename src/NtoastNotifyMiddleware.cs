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

namespace NToastNotify
{
    internal class NtoastNotifyMiddleware : IMiddleware
    {
        private readonly IToastNotification<ILibraryOptions> _toastNotification;
        private readonly ILogger<NtoastNotifyMiddleware> _logger;

        public NtoastNotifyMiddleware(IToastNotification<ILibraryOptions> toastNotification, ILogger<NtoastNotifyMiddleware> logger)
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
                if (_toastNotification.GetToastMessages().ToList().Count > 0)
                {
                    httpContext.Response.Headers.Add(Constants.ResponseHeaderKey, _toastNotification.ReadAllMessages().ToJson());
                }
            }
            return Task.FromResult(0);
        }

    }
}
