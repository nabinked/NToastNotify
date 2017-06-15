using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace NToastNotify
{
    class TempDataWrapper : ITempDataWrapper
    {
        private readonly HttpContext _context;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

        public TempDataWrapper(ITempDataDictionaryFactory tempDataDictionaryFactory, IHttpContextAccessor httpContextAccessor)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _context = httpContextAccessor.HttpContext;
        }
        /// <summary>
        /// Gets or sets <see cref="ITempDataDictionary"/>/>.
        /// </summary>
        private ITempDataDictionary TempData => _tempDataDictionaryFactory?.GetTempData(_context);

        public T Get<T>(string key)
        {
            if (TempData.ContainsKey(key))
            {
                return JsonConvert.DeserializeObject<T>(TempData[key].ToString());
            }
            return default(T);
        }

        public T Peek<T>(string key)
        {
            if (TempData.ContainsKey(key))
            {
                return JsonConvert.DeserializeObject<T>(TempData[key].ToString());
            }
            return default(T);
        }

        public void Add(string key, object value)
        {
            TempData[key] = JsonConvert.SerializeObject(value);
        }
    }
}