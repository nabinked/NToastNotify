namespace NToastNotify
{
    public interface IToastMessage
    {
        string Message { get; }
        ILibraryOptions Options { get; }
    }
}