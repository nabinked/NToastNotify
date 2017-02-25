using System;
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
            if (primary != null && secondary != null)
            {
                foreach (var pi in typeof(T).GetProperties())
                {
                    var priValue = pi.GetGetMethod().Invoke(primary, null);
                    var secValue = pi.GetGetMethod().Invoke(secondary, null);
                    var defValue = CreateDefaultInstance(pi.PropertyType, priValue);
                    if (priValue == null)
                    {
                        pi.GetSetMethod()?.Invoke(primary, new object[] { secValue });
                    }
                }

                return primary;
            }
            else
            {
                return default(T);
            }

        }

        private static object CreateDefaultInstance(Type type, object oVal)
        {
            if (type == typeof(string))
            {
                return oVal as string;
            }
            else
            {

                return Activator.CreateInstance(type);
            }
        }
    }
}
