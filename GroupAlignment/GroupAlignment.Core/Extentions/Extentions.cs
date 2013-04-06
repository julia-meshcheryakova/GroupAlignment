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
    }
}
