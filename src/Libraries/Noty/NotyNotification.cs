using System;
using System.Collections.Generic;

namespace NToastNotify.Libraries.Noty
{
    public class NotyNotification : INotyNotification
    {
        public void AddSuccessToastMessage(string message = null, string title = null, NotyOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddInfoToastMessage(string message = null, string title = null, NotyOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddWarningToastMessage(string message = null, string title = null, NotyOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public void AddErrorToastMessage(string message = null, string title = null, NotyOptions toastOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotyMessage> GetToastMessages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotyMessage> ReadAllMessages()
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void AddToastMessage(string title, string message)
        {
            throw new NotImplementedException();
        }

        public void AddToastMessage(string title, string message, NotyOptions toasILibraryOptions)
        {
            throw new NotImplementedException();
        }
    }
}
