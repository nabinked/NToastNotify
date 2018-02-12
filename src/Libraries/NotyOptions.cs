using NToastNotify.Helpers;

namespace NToastNotify.Libraries
{
    public class NotyOptions : ILibraryOptions
    {
        public string Json => this.ToJson();
    }
}