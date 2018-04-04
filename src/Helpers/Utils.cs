using Microsoft.Extensions.FileProviders;
using NToastNotify.Components;
using System.Reflection;

namespace NToastNotify.Helpers
{
    public class Utils
    {
        private static readonly Assembly ThisAssembly = typeof(NToastNotifyViewComponent).Assembly;

        public static EmbeddedFileProvider GetEmbeddedFileProvider()
        {
            return new EmbeddedFileProvider(ThisAssembly, "NToastNotify");
        }

        public static ILibrary GetLibraryDetails<T>(NToastNotifyOption nToastNotifyOptions) where T : class, ILibrary, new()
        {
            var library = new T();
            if (nToastNotifyOptions != null)
            {
                if (!string.IsNullOrWhiteSpace(nToastNotifyOptions.ScriptSrc))
                {
                    library.ScriptSrc = nToastNotifyOptions.ScriptSrc;
                }
                if (!string.IsNullOrWhiteSpace(nToastNotifyOptions.StyleHref))
                {
                    library.StyleHref = nToastNotifyOptions.StyleHref;
                }
            }
            return library;
        }
    }
}
