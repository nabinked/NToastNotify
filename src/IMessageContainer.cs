using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify
{
    public interface IMessageContainer
    {
        void Add(ToastMessage message);
        void RemoveAll();
        IList<ToastMessage> GetAll();
        IList<ToastMessage> ReadAll();
    }
}
