namespace NToastNotify
{
    public interface IToastMessage
    {
        string Message { get; }
        string Title { get; }
        ILibraryOptions ToastOptions { get; }
    }
}