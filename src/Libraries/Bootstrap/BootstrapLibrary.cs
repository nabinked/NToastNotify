namespace NToastNotify
{
    public class BootstrapLibrary : ILibrary
    {
        public string VarName { get; } = "bootstrap5";
        public string ScriptSrc { get; set; } = "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js";
        public string StyleHref { get; set; } = "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css";
        public LibraryOptions? Options { get; set; }
    }
}