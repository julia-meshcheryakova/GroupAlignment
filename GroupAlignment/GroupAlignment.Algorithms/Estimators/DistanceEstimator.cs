// -----------------------------------------------------------------------
// <copyright file="DistanceEstimator.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace GroupAlignment.Algorithms.Estimators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GroupAlignment.Core.Models;

    /// <summary>
    /// Distance estimator class
    /// </summary>
    public class DistanceEstimator
    {
        /// <summary>
        /// Gets simple distance estimate for 2 sequences
        /// </summary>
        /// <param name="sequence1">The sequence 1.</param>
        /// <param name="sequence2">The sequence 2.</param>
        /// <returns>Distance estimate</returns>
        public double SimpleDistance(BaseSequence sequence1, BaseSequence sequence2)
        {
            var maxLength = Math.Max(sequence1.Value.Count, sequence2.Value.Count);
            this.CompleteSequence(sequence1, maxLength);
            this.CompleteSequence(sequence2, maxLength);
            var pairSequence = this.ToPair(sequence1.Value, sequence2.Value, (x, y) => new { nucl1 = x, nucl2 = y });
            var res = pairSequence.Sum(pair => this.SimpleNucleotideDistance(pair.nucl1, pair.nucl2));
            return res;
            ///// sequence1.Value.Sum((n, i) =>  sequence2.Value[i])
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="n1">The nucleotide 1.</param>
        /// <param name="n2">The nucleotide 2.</param>
        /// <returns>Distance estimate</returns>
        public double SimpleNucleotideDistance(Nucleotide n1, Nucleotide n2)
        {
            return n1 == n2 ? 0 : 1;
        }

        /// <summary>
        /// Completes sequence to the certain length
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="count">The count.</param>
        public void CompleteSequence(BaseSequence sequence, int count)
        {
            var length = sequence.Value.Count;
            if (length >= count)
            {
                return;
            }

            for (var i = 0; i < count - length; ++i)
            {
                sequence.Value.Add(Nucleotide._);
            }
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
        public IEnumerable<TResult> ToPair<TFirst, TSecond, TResult>(List<TFirst> first, List<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            if (first.Count != second.Count)
            {
                throw new Exception();
            }

            return first.Select((t, i) => selector.Invoke(t, second[i]));
        }
    }
}
