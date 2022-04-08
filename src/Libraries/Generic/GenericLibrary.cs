namespace NToastNotify
{
    public class GenericLibrary : ILibrary
    {
        public string VarName { get; } = "generic";
        public string ScriptSrc { get; set; } = "";
        public string StyleHref { get; set; } = "";
        public LibraryOptions? Options { get; set; }
    }
}
