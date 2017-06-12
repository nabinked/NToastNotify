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
        private ITempDataDictionary _tempData;
        private readonly string _key = AppSettings.Key;


        public ToastNotification(IHttpContextAccessor contextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
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

        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType)
        {
            var toastMessage = new ToastMessage(message, title, notificationType);
            AddMessages(toastMessage);
        }
        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, notificationType, toastOptions);
            AddMessages(toastMessage);
        }

        public void AddSuccessToastMessage(string message)
        {
            var toastMessage = new ToastMessage(message, "Success", ToastEnums.ToastType.Success);
            AddMessages(toastMessage);
        }
        
        public void AddSuccessToastMessage(string title, string message)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Success);
            AddMessages(toastMessage);
        }

        public void AddSuccessToastMessage(string title, string message, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Success, toastOptions);
            AddMessages(toastMessage);
        }
        
        public void AddWarningToastMessage(string message)
        {
            var toastMessage = new ToastMessage(message, "Warning", ToastEnums.ToastType.Warning);
            AddMessages(toastMessage);
        }

        public void AddWarningToastMessage(string title, string message)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Warning);
            AddMessages(toastMessage);
        }

        public void AddWarningToastMessage(string title, string message, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Warning, toastOptions);
            AddMessages(toastMessage);
        }
        
        public void AddInfoToastMessage(string message)
        {
            var toastMessage = new ToastMessage(message, "Info", ToastEnums.ToastType.Info);
            AddMessages(toastMessage);
        }

        public void AddInfoToastMessage(string title, string message)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Info);
            AddMessages(toastMessage);
        }

        public void AddInfoToastMessage(string title, string message, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Info, toastOptions);
            AddMessages(toastMessage);
        }
        
        public void AddErrorToastMessage(string message)
        {
            var toastMessage = new ToastMessage(message, "Error", ToastEnums.ToastType.Error);
            AddMessages(toastMessage);
        }

        public void AddErrorToastMessage(string title, string message)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Error);
            AddMessages(toastMessage);
        }

        public void AddErrorToastMessage(string title, string message, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Error, toastOptions);
            AddMessages(toastMessage);
        }

        public IEnumerable<ToastMessage> GetToastMessages()
        {
            return GetMessages();
        }

        #region Privates
        private void AddMessages(ToastMessage toastMessage)
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
