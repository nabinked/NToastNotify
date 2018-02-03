using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace NToastNotify.Helpers
{
    public static class RequestHelpers
    {
        public static bool IsAjaxRequest(this HttpRequest request)
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
