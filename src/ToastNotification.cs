using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace NToastNotify
{
    public class ToastNotification : IToastNotification
    {
        private readonly HttpContext _context;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private ITempDataDictionary _tempData;
        private readonly ToastOption _globaloptions;
        private readonly string _key = AppSettings.Key;


        public ToastNotification(IHttpContextAccessor contextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory, ToastOption toastOptions)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _globaloptions = toastOptions;
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
            var toastMessage = new ToastMessage(message, title, notificationType, _globaloptions);
            AddMessages(toastMessage);


        }

        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, notificationType, toastOptions.MergeWith(_globaloptions));
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