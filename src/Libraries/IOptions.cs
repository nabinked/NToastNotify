using Newtonsoft.Json;

namespace NToastNotify
{
    public interface IOptions
    {
        IOptions Defaults { get; }
        [JsonIgnore]
        string Json { get; }
    }
}