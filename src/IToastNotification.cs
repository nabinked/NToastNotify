using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification<TOptions> where TOptions : class
    {
        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="notificationType">Type of message <seealso cref="Enums.ToastType"/></param>
        void AddToastMessage(string title, string message, Enums.ToastType notificationType);

        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="notificationType">Type of message <seealso cref="Enums.ToastType"/></param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddToastMessage(string title, string message, Enums.ToastType notificationType,
            ILibraryOptions toastOptions);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.ToastType.success"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddSuccessToastMessage(string message = null, string title = null, TOptions toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.ToastType.Info"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddInfoToastMessage(string message = null, string title = null, TOptions toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.ToastType.Warning"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddWarningToastMessage(string message = null, string title = null, TOptions toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.ToastType.Error"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddErrorToastMessage(string message = null, string title = null, TOptions toastOptions = null);

        /// <summary>
        /// Gets the list of <see cref="ToastMessage"/> added so far.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToastMessage> GetToastMessages();

        /// <summary>
        /// Returns a list of <see cref="ToastMessage"/> and removes them from the list of Toast Messages.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToastMessage> ReadAllMessages();

        /// <summary>
        /// Remove all toast notifications
        /// </summary>
        void RemoveAll();
    }
}
