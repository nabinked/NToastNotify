namespace NToastNotify.Libraries
{
    public interface ILibrary<out TOptions>
    {
        /// <summary>
        /// Variable name available to window
        /// </summary>
        string VarName { get; }
        /// <summary>
        /// The src to the script file of the library. Defaults to the cdn link
        /// </summary>
        string ScriptSrc { get; }
        /// <summary>
        /// The href to the stylesheet file of the library. Defaults to the cdn link
        /// </summary>
        string StyleHref { get; }

        /// <summary>
        /// Default options of the javascript library.
        /// </summary>
        TOptions Defaults { get; }

    }
}
