using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify.Libraries.Toastr
{
    public class ToastrNotification : ToastNotification, IToastrNotification
    {
        public ToastrNotification(IMessageContainerFactory messageContainerFactory, NToastNotifyOption nToastNotifyOptions) : base(messageContainerFactory, nToastNotifyOptions)
        {
        }

        public void AddToastMessage(string title, string message, Enums.NotificationTypesToastr notificationType)
        {
            var toastMessage = new ToastrMessage(message, title, notificationType);
            base.AddMessage(toastMessage);
        }

        public void AddToastMessage(string title, string message, Enums.NotificationTypesToastr notificationType, ToastrOptions toasILibraryOptions)
        {
            var toastMessage = new ToastrMessage(message, title, notificationType, toasILibraryOptions);
            base.AddMessage(toastMessage);
        }
    }
}
