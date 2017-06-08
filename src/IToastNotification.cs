using System.Collections.Generic;

namespace NToastNotify
{
    public interface IToastNotification
    {
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);

        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOption toastOptions);
        
        void AddSuccessToastMessage(string title, string message);
        
        void AddSuccessToastMessage(string title, string message, ToastOption toastOptions);
        
        void AddWarningToastMessage(string title, string message);
        
        void AddWarningToastMessage(string title, string message, ToastOption toastOptions);
        
        void AddInfoToastMessage(string title, string message);
        
        void AddInfoToastMessage(string title, string message, ToastOption toastOptions);
        
        void AddErrorToastMessage(string title, string message);
        
        void AddErrorToastMessage(string title, string message, ToastOption toastOptions);
    }
}
