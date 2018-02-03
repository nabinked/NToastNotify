using System;
using System.Collections.Generic;
using System.Text;

namespace NToastNotify
{
    public interface IMessageContainerFactory
    {
        IMessageContainer Create();
    }
}
