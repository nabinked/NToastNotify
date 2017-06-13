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
            AddMessage(toastMessage);
        }
        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, notificationType, toastOptions);
            AddMessage(toastMessage);
        }


        public void AddSuccessToastMessage(string message = "Task Succesfull", string title = "Success", ToastOption option = null)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Success);
            AddMessage(toastMessage);
        }

        public void AddInfoToastMessage(string message, string title = "Info", ToastOption option = null)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Info);
            AddMessage(toastMessage);
        }

        public void AddWarningToastMessage(string message, string title = "Warning", ToastOption option = null)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Warning);
            AddMessage(toastMessage);
        }

        public void AddErrorToastMessage(string message = "There was an error.", string title = "Error", ToastOption option = null)
        {
            var toastMessage = new ToastMessage(message, title, ToastEnums.ToastType.Error);
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
