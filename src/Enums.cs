using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace NToastNotify
{
    public class Enums
    {
        public enum NotificationTypesToastr
        {
            Success,
            Warning,
            Info,
            Error,
        }

        public enum NotificationTypesNoty
        {
            Success,
            Warning,
            Info,
            Error,
            Alert

        }
    }
}
