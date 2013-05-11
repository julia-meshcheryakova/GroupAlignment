
namespace GroupAlignment.Core.Estimators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Models;

    /// <summary>
    /// Distance estimator abstract class
    /// </summary>
    public abstract class AbstractDistanceEstimator
    {
        /// <summary>
        /// Gets simple distance estimate for 2 sequences
        /// </summary>
        /// <param name="sequence1">The sequence 1.</param>
        /// <param name="sequence2">The sequence 2.</param>
        /// <returns>Distance estimate</returns>
        public abstract int Distance(BaseSequence sequence1, BaseSequence sequence2);

        /// <summary>
        /// Gets simple distance estimate for 2 sequences
        /// </summary>
        /// <param name="pair">The sequence pair.</param>
        /// <returns>Distance estimate</returns>
        public abstract double Distance(PairAlignment pair);

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="n1">The nucleotide 1.</param>
        /// <param name="n2">The nucleotide 2.</param>
        /// <returns>Distance estimate</returns>
        public abstract int NucleotideDistance(Nucleotide n1, Nucleotide n2);

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="pair">The nucleotide pair.</param>
        /// <returns>Distance estimate</returns>
        public abstract int NucleotideDistance(NucleotidePair pair);
        
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
