
namespace GroupAlignment.Core.Estimators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;

    /// <summary>
    /// Distance estimator abstract class
    /// </summary>
    public abstract class AbstractDistanceEstimator
    {
        /// <summary>
        /// Gets distance estimate for 2 sequences
        /// </summary>
        /// <param name="sequence1">The sequence 1.</param>
        /// <param name="sequence2">The sequence 2.</param>
        /// <returns>Distance estimate</returns>
        public abstract double Distance(Sequence sequence1, Sequence sequence2);

        /// <summary>
        /// Gets distance estimate for 2 sequences
        /// </summary>
        /// <param name="pair">The sequence pair.</param>
        /// <returns>Distance estimate</returns>
        public abstract double Distance(PairAlignment pair);

        /// <summary>
        /// Gets distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="n1">The nucleotide 1.</param>
        /// <param name="n2">The nucleotide 2.</param>
        /// <returns>Distance estimate</returns>
        public abstract double NucleotideDistance(Nucleotide n1, Nucleotide n2);

        /// <summary>
        /// Gets distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="pair">The nucleotide pair.</param>
        /// <returns>Distance estimate</returns>
        public abstract double NucleotideDistance(NucleotidePair pair);

        /// <summary>
        /// Gets distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="profileItem">The profile item.</param>
        /// <param name="nucleotide">The nucleotide.</param>
        /// <returns>Distance estimate</returns>
        public double ProfileItemNucleotideDistance(ProfileItem profileItem, Nucleotide nucleotide)
        {
            return profileItem.Sum(n => n.Value * this.NucleotideDistance(n.Key, nucleotide));
        }

        /// <summary>
        /// Gets distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="nucleotide">The nucleotide.</param>
        /// <param name="profileItem">The profile item.</param>
        /// <returns>Distance estimate</returns>
        public double ProfileItemNucleotideDistance(Nucleotide nucleotide, ProfileItem profileItem)
        {
            return profileItem.Sum(n => n.Value * this.NucleotideDistance(n.Key, nucleotide));
        }

        /// <summary>
        /// Gets distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="profileItem1">The profile item 1.</param>
        /// <param name="profileItem2">The profile item 2.</param>
        /// <returns>Distance estimate</returns>
        public double ProfileItemsDistance(ProfileItem profileItem1, ProfileItem profileItem2)
        {
            return
                (from i1 in profileItem1
                 from i2 in profileItem2
                 select i1.Value * i2.Value * this.NucleotideDistance(i1.Key, i2.Key)).Sum();
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
