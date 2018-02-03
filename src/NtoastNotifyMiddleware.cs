using System;
using System.Collections.Generic;
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
        private readonly IToastNotification _toastNotification;
        private readonly ILogger<NtoastNotifyMiddleware> _logger;

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
            _logger.LogInformation("CallBack method called");
            if (httpContext.Request.IsAjaxRequest())
            {
                _logger.LogInformation("An ajax request.");
                _logger.LogInformation(_toastNotification.GetToastMessages().ToJson());
                httpContext.Response.Headers.Add(Constants.ResponseHeaderKey, _toastNotification.ReadAllMessages().ToJson());
            }
            return Task.FromResult(0);
        }

    }
}
