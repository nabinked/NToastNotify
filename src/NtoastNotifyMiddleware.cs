using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NToastNotify.Helpers;

namespace NToastNotify
{
    internal class NtoastNotifyMiddleware : IMiddleware
    {
        private readonly IToastNotification _toastNotification;

        public NtoastNotifyMiddleware(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
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
                httpContext.Response.Headers.Add(Constants.ResponseHeaderKey,
                        JsonConvert.SerializeObject(_toastNotification.ReadAllMessages(), JsonSerialization.JsonSerializerSettings));
            }
            return Task.FromResult(0);
        }

    }
}
