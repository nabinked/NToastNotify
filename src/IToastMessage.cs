using NToastNotify.Libraries;

namespace NToastNotify
{
    public interface IToastMessage<out TOptions> where TOptions : class, ILibraryOptions
    {
        string Message { get; }
        string Title { get; }
        TOptions ToastOptions { get; }
    }
}