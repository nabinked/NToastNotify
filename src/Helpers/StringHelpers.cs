using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Helpers
{
    public static class StringHelpers
    {
        public static HtmlString ToHtmlString(this string str)
        {
            return new HtmlString(str);
        }
    }
}
