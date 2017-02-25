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

        private readonly string _key = AppSettings.Key;
        private ITempDataDictionary _tempData;
        private ToastOption _globaloptions;

        public ToastNotification(ITempDataProvider tempDataProvider, IHttpContextAccessor contextAccessor, ToastOption toastOptions)
        {
            this._globaloptions = toastOptions;
            _context = contextAccessor.HttpContext;
        }

        /// <summary>
        /// Gets or sets <see cref="ITempDataDictionary"/> used by <see cref="ViewResult"/>.
        /// </summary>
        public ITempDataDictionary TempData
        {
            get
            {
                if (_tempData == null)
                {
                    var factory = _context?.RequestServices?.GetRequiredService<ITempDataDictionaryFactory>();
                    _tempData = factory?.GetTempData(_context);
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
            AddToastMessage(toastMessage);


        }

        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType, ToastOption toastOptions)
        {
            var toastMessage = new ToastMessage(message, title, notificationType, toastOptions.MergeWith(_globaloptions));
            AddToastMessage(toastMessage);

        }

        private void AddToastMessage(ToastMessage toastMessage)
        {

            IList<ToastMessage> messages = new List<ToastMessage>();
            if (TempData.ContainsKey(_key))
            {
                messages = JsonConvert.DeserializeObject<IList<ToastMessage>>((string)TempData[_key]) ?? new List<ToastMessage>();
            }
            messages.Add(toastMessage);
            var messagesSerialized = JsonConvert.SerializeObject(messages);
            TempData[_key] = messagesSerialized;
        }
    }
}