namespace NToastNotify.Libraries.Noty
{
    public interface INotyNotification : IToastNotification<NotyLibrary, NotyOptions, NotyMessage>
    {
        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        void AddToastMessage(string title, string message);

        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="toasILibraryOptions">options</param>
        void AddToastMessage(string title, string message, NotyOptions toasILibraryOptions);
    }
}
