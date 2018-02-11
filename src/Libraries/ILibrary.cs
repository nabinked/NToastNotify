using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries
{
    public interface ILibrary<TOption>
    {
        string Name { get; set; }
        string ScriptSrc { get; set; }
        string StyleHref { get; set; }
        TOption Options { get; set; }

    }
}
