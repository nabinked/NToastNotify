using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace NToastNotify
{
    public class Enums
    {
        public enum ToastType
        {
            Success,
            Warning,
            Info,
            Error,
            //This one used in Noty
            Alert

        }
    }
}
