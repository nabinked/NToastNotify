using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NToastNotify.Helpers;

namespace NToastNotify
{
    internal class NtoastNotifyAjaxToastsMiddleware : IMiddleware
    {
        private readonly IToastNotification _toastNotification;
        private readonly ILogger<NtoastNotifyAjaxToastsMiddleware> _logger;
        private readonly NToastNotifyOption _nToastNotifyOption;
        private const string AccessControlExposeHeadersKey = "Access-Control-Expose-Headers";
        public NtoastNotifyAjaxToastsMiddleware(IToastNotification toastNotification, ILogger<NtoastNotifyAjaxToastsMiddleware> logger, NToastNotifyOption nToastNotifyOption)
        {
            _toastNotification = toastNotification;
            _logger = logger;
            _nToastNotifyOption = nToastNotifyOption;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            context.Response.OnStarting(Callback, context);
            await next(context);
        }

        private Task Callback(object context)
        {
            var httpContext = (HttpContext)context;
            if (!_nToastNotifyOption.DisableAjaxToasts && httpContext.Request.IsNtoastNotifyAjaxRequest())
            {
                var messages = _toastNotification.ReadAllMessages();
                if (messages != null && messages.Any())
                {
                    var accessControlExposeHeaders = $"{GetControlExposeHeaders(httpContext.Response.Headers)}";
                    _logger.LogInformation($"Setting response header {AccessControlExposeHeadersKey} with {accessControlExposeHeaders}");
                    httpContext.Response.Headers.Add(AccessControlExposeHeadersKey, accessControlExposeHeaders);

                    var messagesJson = messages.ToJson();
                    _logger.LogInformation($"Setting response header {Constants.ResponseHeaderKey} with {messagesJson}");
                    httpContext.Response.Headers.Add(Constants.ResponseHeaderKey, messagesJson);
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
