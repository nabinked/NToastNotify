using System;
using Microsoft.AspNetCore.Http;

namespace NToastNotify.Helpers
{
    public static class RequestHelpers
    {
        public static bool IsNtoastNotifyAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!string.IsNullOrWhiteSpace(request.Headers[Constants.RequestHeaderKey]))
            {
                return true;
            };
            if (!string.IsNullOrWhiteSpace(request.Headers[Constants.RequestHeaderKey.ToLower()]))
            {
                return true;
            }

            return false;
        }
    }
}
