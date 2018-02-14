using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries
{
    public class Noty : ILibrary
    {
        public string VarName { get; set; } = "noty";
        public string ScriptSrc { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.js";
        public string StyleHref { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.css";
    }
}
