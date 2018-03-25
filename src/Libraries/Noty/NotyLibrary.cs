namespace NToastNotify
{
    public class NotyLibrary : ILibrary
    {
        public string VarName { get; } = "noty";
        public string ScriptSrc { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.js";
        public string StyleHref { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.css";
    }
}
