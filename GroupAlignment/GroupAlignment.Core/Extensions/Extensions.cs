
namespace GroupAlignment.Core.Extensions
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

        /// <summary>
        /// The equals method for 2 double values.
        /// </summary>
        /// <param name="value1">The value 1.</param>
        /// <param name="value2">The value 2.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool AreEqual(this double value1, double value2)
        {
            var difference = .000001;
            return Math.Abs(value1 - value2) <= difference;
        }
    }
}
