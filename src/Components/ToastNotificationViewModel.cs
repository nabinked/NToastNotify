namespace NToastNotify.Components
{
    public class ToastNotificationViewModel
    {
        /// <summary>
        /// JSON string of arrays of message
        /// </summary>
        public string ToastMessagesJson { get; set; }
        /// <summary>
        /// Request header key used to show toast notification in AJAX calls
        /// </summary>
        public string RequestHeaderKey { get; set; }
        /// <summary>
        /// Response header key used to show toast notification in AJAX calls
        /// </summary>
        public string ResponseHeaderKey { get; set; }
        /// <summary>
        /// Library details 
        /// </summary>
        public ILibrary LibraryDetails { get; set; }
        /// <summary>
        /// This is used to get the hash of the javascript file using the last modified date. Used for cache busting.
        /// </summary>
        public string Hash { get; set; }
    }
}
