
namespace GroupAlignment.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    using GroupAlignment.Core.Models;

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
        /// The string to sequence convert.
        /// </summary>
        /// <param name="sequence">The sequence string.</param>
        /// <returns>The <see cref="Sequence"/>. </returns>
        public static Sequence StringToSequence(this string sequence)
        {
            return new Sequence(sequence.ToCharArray().Select(ch => ch.CharToNucleotide()).ToList());
        }

        /// <summary>
        /// The char to nucleotide convert.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The <see cref="Nucleotide"/>.</returns>
        public static Nucleotide CharToNucleotide(this char symbol)
        {
            try
            {
                return (Nucleotide)Enum.Parse(typeof(Nucleotide), symbol.ToString());
            }
            catch (Exception)
            {
                return Nucleotide.N;
            }
        }

        /// <summary>
        /// The add range method for dictionary. If the key exists - value is updated.
        /// </summary>
        /// <param name="source">The source dictionary.</param>
        /// <param name="collection">The collection.</param>
        /// <typeparam name="T">Key type.</typeparam>
        /// <typeparam name="TS">Value type.</typeparam>
        public static void AddRange<T, TS>(this Dictionary<T, TS> source, IEnumerable<KeyValuePair<T, TS>> collection)
        {
            if (collection == null)
            {
                return;
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
        public static bool IsEqualTo(this double value1, double value2)
        {
            const double Difference = .000001;
            return Math.Abs(value1 - value2) <= Difference;
        }

        /// <summary>
        /// Combines 2 lists to one
        /// </summary>
        /// <param name="first">The first list.</param>
        /// <param name="second">The second list.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TFirst">First type</typeparam>
        /// <typeparam name="TSecond">Second type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <returns>Pair list</returns>
        /// <exception cref="Exception">Exception - if length are different</exception>
        public static IEnumerable<TResult> ToPair<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            var list1 = first.ToList();
            var list2 = second.ToList();
            if (list1.Count != list2.Count)
            {
                throw new Exception();
            }

            return list1.Select((t, i) => selector.Invoke(t, list2[i]));
        }

        /// <summary>
        /// The deep clone.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public static object DeepClone(this object obj)
        {
            object objResult = null;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }

            return objResult;
        }
    }
}
