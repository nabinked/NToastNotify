using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries
{
    public interface ILibrary<out TOptions>
    {
        string VarName { get; }
        string ScriptSrc { get; }
        string StyleHref { get; }
        TOptions Defaults { get; }

    }
}
