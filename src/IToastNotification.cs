using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOption toastOptions);
        IEnumerable<ToastMessage> GetToastMessages();
    }
}
