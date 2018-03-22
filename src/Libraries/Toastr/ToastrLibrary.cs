namespace NToastNotify.Libraries
{
    public class ToastrLibrary : ILibrary<IToastrJsOptions>
    {
        public string VarName { get; set; } = "toastr";
        public string ScriptSrc { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js";
        public string StyleHref { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css";
        public IToastrJsOptions Defaults => DefaultOptions.Toastr;
    }
}
