namespace NToastNotify
{
    public class ToastMessage
    {
        public ToastMessage(string message, string title, ToastEnums.ToastType toasType, ToastOption options = null)
        {
            this.Message = message;
            this.Title = title;
            this.ToastType = toasType;
            this.ToastOptions = options;
        }
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastEnums.ToastType ToastType { get; set; }
        public ToastOption ToastOptions { get; set; }
    }
}
