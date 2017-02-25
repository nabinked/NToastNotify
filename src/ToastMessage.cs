using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NToastNotify
{
    public class ToastMessage
    {
        private ToastOption _toastOptions;
        [JsonConstructor]
        public ToastMessage(ToastOption options)
        {
            _toastOptions = options;
        }
        public ToastMessage(string message, string title, ToastEnums.ToastType toasType, ToastOption options)
        {
            this.Message = message;
            this.Title = title;
            this.ToastType = toasType;
            this.ToastOptions = options;
        }
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastEnums.ToastType ToastType { get; set; }
        public ToastOption ToastOptions
        {
            get
            {
                return _toastOptions;
            }
            set
            {
                if (value != null)
                {
                    this._toastOptions = value.MergeWith(ToastOption.Defaults);
                }
            }
        }
        public string ToastOptionsJson => JsonConvert.SerializeObject(ToastOptions, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

    }
}
