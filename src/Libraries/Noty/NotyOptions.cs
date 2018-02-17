using NToastNotify.Helpers;

namespace NToastNotify
{
    public class NotyOptions : ILibraryOptions
    {
        public string Json => this.ToJson();
    }
}