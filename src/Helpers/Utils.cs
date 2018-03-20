using Microsoft.Extensions.FileProviders;
using NToastNotify.Components;
using System.Reflection;

namespace NToastNotify.Helpers
{
    public class Utils
    {
        private static readonly Assembly ThisAssembly = typeof(ToastViewComponent).Assembly;

        public static EmbeddedFileProvider GetEmbeddedFileProvider()
        {
          return new EmbeddedFileProvider(ThisAssembly, "NToastNotify");
        }
    }
}
