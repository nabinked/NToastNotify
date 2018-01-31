using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {
        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="notificationType">Type of message <seealso cref="ToastEnums.ToastType"/></param>
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);

        /// <summary>
        /// Adds a toast message to render to the view.
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The actual message body</param>
        /// <param name="notificationType">Type of message <seealso cref="ToastEnums.ToastType"/></param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="ToastOption"/></param>
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOption toastOptions);
        
        /// <summary>
        /// Adds a toast message of type <see cref="ToastEnums.ToastType.Success"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="ToastOption"/></param>
        void AddSuccessToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="ToastEnums.ToastType.Info"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="ToastOption"/></param>
        void AddInfoToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="ToastEnums.ToastType.Warning"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="ToastOption"/></param>
        void AddWarningToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="ToastEnums.ToastType.Error"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="ToastOption"/></param>
        void AddErrorToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        /// <summary>
        /// Peeks the list of <see cref="ToastMessage"/> added so far. Peeking messages does not delete the messages
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToastMessage> PeekToastMessages();

        /// <summary>
        /// Gets the list of <see cref="ToastMessage"/> added so far. Getting list of messages will remove them from the list of Toast Messages.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToastMessage> GetToastMessages();
    }
}
