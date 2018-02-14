using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries
{
    public interface ILibrary
    {
        string VarName { get; }
        string ScriptSrc { get; }
        string StyleHref { get; }
        ILibraryOptions Defaults { get; }

    }
}
