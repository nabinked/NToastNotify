namespace NToastNotify
{
    public interface ILibrary
    {
        /// <summary>
        /// Variable name available to window
        /// </summary>
        string VarName { get; }
        /// <summary>
        /// The src to the script file of the library. Defaults to the cdn link
        /// </summary>
        string ScriptSrc { get; set; }
        /// <summary>
        /// The href to the stylesheet file of the library. Defaults to the cdn link
        /// </summary>
        string StyleHref { get; set; }

        LibraryOptions Options { get; set; }
    }
}
