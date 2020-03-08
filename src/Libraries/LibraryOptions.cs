using Newtonsoft.Json;

namespace NToastNotify
{
    public abstract class LibraryOptions
    {
        [JsonIgnore]
        public abstract string Json { get; }
    }
}
