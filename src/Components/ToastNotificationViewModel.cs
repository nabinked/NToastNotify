namespace NToastNotify.Components
{
    public class ToastNotificationViewModel
    {
        public ToastNotificationViewModel(string toastMessagesJson, string requestHeaderKey, string responseHeaderKey, ILibrary libraryDetails, bool disableAjaxToasts, string libraryJsPath, string? nonce)
        {
            ToastMessagesJson = toastMessagesJson;
            RequestHeaderKey = requestHeaderKey;
            ResponseHeaderKey = responseHeaderKey;
            LibraryDetails = libraryDetails;
            DisableAjaxToasts = disableAjaxToasts;
            LibraryJsPath = libraryJsPath;
            Nonce = nonce;
        }

        /// <summary>
        /// JSON string of arrays of message
        /// </summary>
        public string ToastMessagesJson { get; }

        /// <summary>
        /// Request header key used to show toast notification in AJAX calls
        /// </summary>
        public string RequestHeaderKey { get; }

        /// <summary>
        /// Response header key used to show toast notification in AJAX calls
        /// </summary>
        public string ResponseHeaderKey { get; }

        /// <summary>
        /// Library details 
        /// </summary>
        public ILibrary LibraryDetails { get; set; }

        /// <summary>
        /// If set to true, Ajax toasts will be disabled.
        /// </summary>
        public bool DisableAjaxToasts { get; set; }

        /// <summary>
        /// The path of the js
        /// </summary>
        public string LibraryJsPath { get; set; }

        /// <summary>
        /// Nonce value for allow the inline script to run if CSP is set 
        /// </summary>
        public string? Nonce { get; set; }
    }
}
