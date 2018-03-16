using NToastNotify.Helpers;

namespace NToastNotify.Libraries.Noty
{
    public class NotyOptions : ILibraryOptions
    {
        public string Json => this.ToJson();
    }
}