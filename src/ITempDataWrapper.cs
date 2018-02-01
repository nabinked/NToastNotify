namespace NToastNotify
{
    public interface ITempDataWrapper
    {
        T Get<T>(string key);
        T Peek<T>(string key);
        void Add(string key, object value);
        bool Remove(string key);
    }
}
