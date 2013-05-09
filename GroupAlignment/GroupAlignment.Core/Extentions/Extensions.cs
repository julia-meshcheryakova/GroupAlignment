namespace GroupAlignment.Core.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The clone.
        /// </summary>
        /// <param name="listToClone">The list to clone.</param>
        /// <typeparam name="T">Type used.</typeparam>
        /// <returns>The IList object.</returns>
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// The clone enumeration list.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <typeparam name="T">Type used</typeparam>
        /// <returns>The list.</returns>
        public static List<T> CloneEnumList<T>(this IEnumerable<T> oldList)
        {
            return new List<T>(oldList);
        }

        /// <summary>
        /// The add range method for dictionary. If the key exists - value is updated.
        /// </summary>
        /// <param name="source">The source dictionary.</param>
        /// <param name="collection">The collection.</param>
        /// <typeparam name="T">Key type.</typeparam>
        /// <typeparam name="TS">Value type.</typeparam>
        public static void AddRange<T, TS>(this Dictionary<T, TS> source, Dictionary<T, TS> collection)
        {
            if (collection == null)
            {
                collection = new Dictionary<T, TS>();
            }

            if (source == null)
            {
                source = new Dictionary<T, TS>();
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
                else
                {
                    source[item.Key] = item.Value;
                }
            }
        }
    }
}
