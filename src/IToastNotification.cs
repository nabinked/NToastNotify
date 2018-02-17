using NToastNotify.Libraries;
using System;
using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.NotificationTypesToastr.success"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddSuccessToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.NotificationTypesToastr.Info"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddInfoToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.NotificationTypesToastr.Warning"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddWarningToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null);

        /// <summary>
        /// Adds a toast message of type <see cref="Enums.NotificationTypesToastr.Error"/>
        /// </summary>
        /// <param name="message">Messsage body</param>
        /// <param name="title">Title of the message</param>
        /// <param name="toastOptions">Custom option for the message being added. <see cref="Option"/></param>
        void AddErrorToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null);

        /// <summary>
        /// Gets the list of <see cref="ToastrMessage"/> added so far.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IToastMessage> GetToastMessages();

        /// <summary>
        /// Returns a list of <see cref="ToastrMessage"/> and removes them from the list of Toast Messages.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IToastMessage> ReadAllMessages();

        /// <summary>
        /// Remove all toast notifications
        /// </summary>
        void RemoveAll();
    }
}
