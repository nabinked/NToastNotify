namespace NToastNotify
{
    public interface ITempDataWrapper
    {
        T Get<T>(string key) where T : class;
        T Peek<T>(string key) where T : class;
        void Add(string key, object value);
        /// <summary>
        /// Remove value with a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(string key);
    }
}
