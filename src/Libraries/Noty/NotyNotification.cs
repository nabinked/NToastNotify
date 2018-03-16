using System;
using System.Collections.Generic;

namespace NToastNotify.Libraries.Noty
{
    public class NotyNotification : IToastNotification
    {
        public void AddSuccessToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddInfoToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddAlertToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddWarningToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddErrorToastMessage(string message = null, string title = null, ILibraryOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToastMessage> GetToastMessages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToastMessage> ReadAllMessages()
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

    }
}
