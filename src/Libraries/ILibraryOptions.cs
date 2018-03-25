using Newtonsoft.Json;

namespace NToastNotify
{
    public interface ILibraryOptions
    {
        [JsonIgnore]
        string Json { get; }
    }
}