using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace NToastNotify
{
    public class ToastNotification : IToastNotification
    {
        private readonly HttpContext _context;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly NToastNotifyOptions _defaultMessageOptions;
        private ITempDataDictionary _tempData;
        private readonly string _key = AppSettings.Key;


        public ToastNotification(IHttpContextAccessor contextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory,
            NToastNotifyOptions nToastNotifyOptions)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _defaultMessageOptions = nToastNotifyOptions.MergeWith(NToastNotifyOptions.Defaults);
            _context = contextAccessor.HttpContext;
        }

        /// <summary>
        /// Gets or sets <see cref="ITempDataDictionary"/>/>.
        /// </summary>
        public ITempDataDictionary TempData
        {
            get
            {
                if (_tempData == null)
                {
                    _tempData = _tempDataDictionaryFactory?.GetTempData(_context);
                }

                return _tempData;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _tempData = value;
            }
        }

        public NToastNotifyOptions NToastNotifyOptions { get; }

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
            var toastMessage = new ToastMessage(message ?? _defaultMessageOptions.SuccessMessage, title ?? _defaultMessageOptions.SuccessTitle, ToastEnums.ToastType.Success, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddInfoToastMessage(string message, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultMessageOptions.InfoMessage, title ?? _defaultMessageOptions.InfoTitle, ToastEnums.ToastType.Info, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddWarningToastMessage(string message = null, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultMessageOptions.WarningMessage, title ?? _defaultMessageOptions.WarningTitle, ToastEnums.ToastType.Warning, toastOptions);
            AddMessage(toastMessage);
        }

        public void AddErrorToastMessage(string message = null, string title = null, ToastOption toastOptions = null)
        {
            var toastMessage = new ToastMessage(message ?? _defaultMessageOptions.ErrorMessage, title ?? _defaultMessageOptions.ErrorTitle, ToastEnums.ToastType.Error, toastOptions);
            AddMessage(toastMessage);
        }

        public IEnumerable<ToastMessage> GetToastMessages()
        {
            return GetMessages();
        }

        #region Privates
        private void AddMessage(ToastMessage toastMessage)
        {

            IList<ToastMessage> messages = new List<ToastMessage>();
            if (TempData.ContainsKey(_key))
            {
                messages = JsonConvert.DeserializeObject<IList<ToastMessage>>((string)TempData[_key]) ??
                           new List<ToastMessage>();
            }
            messages.Add(toastMessage);
            var messagesSerialized = JsonConvert.SerializeObject(messages);
            TempData[_key] = messagesSerialized;
        }

        private IEnumerable<ToastMessage> GetMessages()
        {
            object messages = TempData[_key];
            var toastMessages = messages == null
                ? new List<ToastMessage>()
                : JsonConvert.DeserializeObject<IList<ToastMessage>>((string)messages);
            return toastMessages;
        }

        #endregion
    }
}
