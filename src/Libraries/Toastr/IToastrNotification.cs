namespace NToastNotify.Libraries.Toastr
{
    public interface IToastrNotification : IToastNotification<ToastrLibrary, ToastrOptions, ToastrMessage>
    {
        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="notificationType">Type of message <seealso cref="Enums.NotificationTypesToastr"/></param>
        void AddToastMessage(string title, string message, Enums.NotificationTypesToastr notificationType);

        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="notificationType">Type of message <seealso cref="Enums.NotificationTypesToastr"/></param>
        /// <param name="toasILibraryOptions">options</param>
        void AddToastMessage(string title, string message, Enums.NotificationTypesToastr notificationType, ToastrOptions toasILibraryOptions);


    }
}
