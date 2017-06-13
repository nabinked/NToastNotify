using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOption toastOptions);

        void AddSuccessToastMessage(string message = "Task Succesfull.", string title = "Success", ToastOption option = null);

        void AddInfoToastMessage(string message, string title = "Info", ToastOption option = null);

        void AddWarningToastMessage(string message, string title = "Warning", ToastOption option = null);

        void AddErrorToastMessage(string message = "There was an error.", string title = "Error", ToastOption option = null);

        IEnumerable<ToastMessage> GetToastMessages();
    }
}
