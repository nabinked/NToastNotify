using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries
{
    public abstract class Toastr : ILibrary<ToastrOptions>
    {
        public string Name { get; set; } = "noty";
        public string ScriptSrc { get; set; }
        public string StyleHref { get; set; }
        public ToastrOptions Options { get; set; }
    }
}
