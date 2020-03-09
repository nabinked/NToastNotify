using Newtonsoft.Json;
using System;

namespace NToastNotify
{
    [Obsolete("Consider using LibraryOptions base class instead of ILibraryOptions",true)]
    public interface ILibraryOptions
    {
        [JsonIgnore]
        string Json { get; }
    }
}