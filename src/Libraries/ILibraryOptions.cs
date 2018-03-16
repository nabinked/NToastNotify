using Newtonsoft.Json;

namespace NToastNotify.Libraries
{
    public interface ILibraryOptions
    {
        [JsonIgnore]
        string Json { get; }
    }
}