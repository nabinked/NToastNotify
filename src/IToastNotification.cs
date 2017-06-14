using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOption toastOptions);

        void AddSuccessToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        void AddInfoToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        void AddWarningToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        void AddErrorToastMessage(string message = null, string title = null, ToastOption toastOptions = null);

        IEnumerable<ToastMessage> GetToastMessages();
    }
}
