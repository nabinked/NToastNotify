namespace NToastNotify
{
    public interface IToastMessage
    {
        string Message { get; }
        LibraryOptions Options { get; }
    }
}