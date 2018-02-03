namespace NToastNotify
{
    public interface ITempDataWrapper
    {
        T Get<T>(string key);
        T Peek<T>(string key);
        void Add(string key, object value);
        /// <summary>
        /// Remove value with a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(string key);
    }
}
