using System.Collections.Generic;

namespace NToastNotify
{
    public class ToastList<T> : List<T> where T : ToastMessage
    {

        public new void Add(T item)
        {
            
        }
    }
}
