using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {

        /// <summary>
        /// Adds a toast message of type success
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. Please provide an instance of the relative options class for the js library that is being used which implements <see cref="LibraryOptions"/></param>
        void AddSuccessToastMessage(string? message = null, LibraryOptions? toastOptions = null);

        /// <summary>
        /// Adds a toast message of type info"
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. Please provide an instance of the relative options class for the js library that is being used which implements <see cref="LibraryOptions"/></param>
        void AddInfoToastMessage(string? message = null, LibraryOptions? toastOptions = null);

        /// <summary>
        /// Adds a toast message of type alert"
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. Please provide an instance of the relative options class for the js library that is being used which implements <see cref="LibraryOptions"/></param>
        void AddAlertToastMessage(string? message = null, LibraryOptions? toastOptions = null);

        /// <summary>
        /// Adds a toast message of type warning"
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. Please provide an instance of the relative options class for the js library that is being used which implements <see cref="LibraryOptions"/></param>
        void AddWarningToastMessage(string? message = null, LibraryOptions? toastOptions = null);

        /// <summary>
        /// Adds a toast message of type error
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. Please provide an instance of the relative options class for the js library that is being used which implements <see cref="LibraryOptions"/></param>
        void AddErrorToastMessage(string? message = null, LibraryOptions? toastOptions = null);

        /// <summary>
        /// Gets the list of <see cref="IToastMessage"/> added so far.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IToastMessage> GetToastMessages();

        /// <summary>
        /// Returns a list of <see cref="IToastMessage"/> and removes them from the list of Toast Messages.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IToastMessage> ReadAllMessages();

        /// <summary>
        /// Remove all toast notifications
        /// </summary>
        void RemoveAll();
    }
}
