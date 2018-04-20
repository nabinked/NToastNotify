using System.Reflection;

namespace NToastNotify
{
    public static class OptionMerger
    {
        public static T MergeWith<T>(this T primary, T secondary)
        {
            if (primary == null)
            {
                return secondary;
            }
            if (secondary == null)
            {
                return primary;
            }
            foreach (var pi in typeof(T).GetProperties())
            {
                var priValue = pi.GetGetMethod().Invoke(primary, null);
                var secValue = pi.GetGetMethod().Invoke(secondary, null);
                if (priValue == null)
                {
                    pi.GetSetMethod()?.Invoke(primary, new[] { secValue });
                }
            }

            return primary;
        }
    }
}
