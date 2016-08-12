using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NToastNotify
{
    public class  ToastMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastEnums.ToastType ToastType { get; set; }
        public ToastOptions ToastOptions { get; set; } = new ToastOptions();

        public string ToastOptionsJson => JsonConvert.SerializeObject(ToastOptions, new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()});


        public bool IsDisplayed { get; set; }

    }
}
