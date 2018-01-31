using System.Collections.Generic;

namespace NToastNotify
{
    public class ToastNotification : IToastNotification
    {

        private readonly NToastNotifyOption _defaultNtoastNotifyOptions;
        private readonly ITempDataWrapper _tempDataWrapper;
        private readonly string _key = Constants.TempDataKey;

        /// <summary>
        /// Toast notification constructor
        /// </summary>
        /// <param name="tempDataWrapper"><see cref="ITempDataWrapper"/></param>
        /// <param name="nToastNotifyOptions">Default toast notify options</param>
        public ToastNotification(ITempDataWrapper tempDataWrapper, NToastNotifyOption nToastNotifyOptions)
        {
            _tempDataWrapper = tempDataWrapper;
            _defaultNtoastNotifyOptions = nToastNotifyOptions.MergeWith(NToastNotifyOption.Defaults);
        }

        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType)
        {
            var toastMessage = new ToastMessage(message, title, notificationType);
            AddMessage(toastMessage);
        }
        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, notificationType, toastOptions);
            AddMessage(toastMessage);
        }


        public void AddSuccessToastMessage(string message = null, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.SuccessMessage, title ?? _defaultNtoastNotifyOptions.SuccessTitle, ToastEnums.ToastType.Success, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddInfoToastMessage(string message, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.InfoMessage, title ?? _defaultNtoastNotifyOptions.InfoTitle, ToastEnums.ToastType.Info, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddWarningToastMessage(string message = null, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.WarningMessage, title ?? _defaultNtoastNotifyOptions.WarningTitle, ToastEnums.ToastType.Warning, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddErrorToastMessage(string message = null, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultNtoastNotifyOptions.ErrorMessage, title ?? _defaultNtoastNotifyOptions.ErrorTitle, ToastEnums.ToastType.Error, toastOptions);
            AddMessage(toastMessage);
        }

        public IEnumerable<ToastMessage> PeekToastMessages()
        {
            return _tempDataWrapper.Peek<IEnumerable<ToastMessage>>(_key);
        }

        public IEnumerable<ToastMessage> GetToastMessages()
        {
            return _tempDataWrapper.Get<IEnumerable<ToastMessage>>(_key);
        }

        #region Privates
        private void AddMessage(ToastMessage toastMessage)
        {
            var messages = _tempDataWrapper.Get<IList<ToastMessage>>(_key) ?? new List<ToastMessage>();
            messages.Add(toastMessage);
            _tempDataWrapper.Add(_key, messages);
        }
        
        #endregion
    }
}
