using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries
{
    public class Noty : ILibrary<NotyOptions>
    {
        public string Name { get; set; }
        public string ScriptSrc { get; set; }
        public string StyleHref { get; set; }
        public Noty Options { get; set; }
    }
}
