using NToastNotify;
using NToastNotify.Helpers;

namespace GenericDevExtreme
{
    public class DevExtremeToastOptions : GenericOptions
    {
        public int DisplayTime { get; set; }

        public override string Json => this.ToJson();
    }
}
