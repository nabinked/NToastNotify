using NToastNotify.Libraries;

namespace NToastNotify
{
    public interface IToastMessage
    {
        string Message { get; }
        ILibraryOptions ToastOptions { get; }
    }
}