using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NToastNotify
{
    public class ToastOptions
    {
        //Many more options to add
        public bool TapToDismiss { get; set; } = true;
        public string ToastClass { get; set; } = "toast";
        public string ContainerId { get; set; } = "toast-container";

        public bool CloseButton { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool NewestOnTop { get; set; } = true;
        public bool ProgressBar { get; set; } = true;
        public string PositionClass { get; set; } = GetPositionCss();
        public bool PreventDuplicates { get; set; } = false;
        public string Onclick { get; set; }
        public int ShowDuration { get; set; } = 300;
        public int HideDuration { get; set; } = 1000;
        public int TimeOut { get; set; } = 5000;
        public int ExtendedTimeOut { get; set; } = 1000;
        public string ShowEasing { get; set; } = "swing";
        public string HideEasing { get; set; } = "linear";
        public string ShowMethod { get; set; } = "fadeIn";
        public string HideMethod { get; set; } = "fadeOut";

        private static string GetPositionCss(ToastEnums.ToastDisplayPosition toastDisplayPosition = ToastEnums.ToastDisplayPosition.BottomLeft)
        {
            switch (toastDisplayPosition)
            {
                case ToastEnums.ToastDisplayPosition.TopRight:
                    return "toast-top-right";
                case ToastEnums.ToastDisplayPosition.BottomRight:
                    return "toast-bottom-right";
                case ToastEnums.ToastDisplayPosition.BottomLeft:
                    return "toast-bottom-left";
                case ToastEnums.ToastDisplayPosition.TopLeft:
                    return "toast-top-left";
                case ToastEnums.ToastDisplayPosition.TopFullWidth:
                    return "toast-top-full-width";
                case ToastEnums.ToastDisplayPosition.BottomFullWidth:
                    return "toast-bottom-full-width";
                case ToastEnums.ToastDisplayPosition.TopCenter:
                    return "toast-top-center";
                case ToastEnums.ToastDisplayPosition.BottomCenter:
                    return "toast-bottom-center";
                default:
                    return "toast-bottom-left";




            }


        }

        public static string DefaultToastOptionsJson => JsonConvert.SerializeObject(new ToastOptions(), new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

    }
}
