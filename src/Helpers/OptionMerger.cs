namespace NToastNotify.Helpers
{
    public static class OptionMerger
    {
        /// <summary>
        /// Merges two object values. Value of the properties of the first object are overriden by the value of 2nd object's property if the first object's property is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primary"></param>
        /// <param name="secondary"></param>
        /// <returns>primary object merged with values of secondary object</returns>
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
                var priValue = pi.GetGetMethod()?.Invoke(primary, null);
                var secValue = pi.GetGetMethod()?.Invoke(secondary, null);
                if (priValue is null)
                {
                    pi.GetSetMethod()?.Invoke(primary, new[] { secValue });
                }
            }

            return primary;
        }
    }
}
