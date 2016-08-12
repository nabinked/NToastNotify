using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {
        IList<ToastMessage> ToastMessages { get; set; }
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);

        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOptions toastOptions);
    }
}
