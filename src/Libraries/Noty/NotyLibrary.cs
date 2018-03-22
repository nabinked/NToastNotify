namespace NToastNotify.Libraries
{
    public class NotyLibrary : ILibrary<INotyJsOptions>
    {
        public string VarName { get; set; } = "noty";
        public string ScriptSrc { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.js";
        public string StyleHref { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.css";

        public INotyJsOptions Defaults => DefaultOptions.Noty;
    }
}
