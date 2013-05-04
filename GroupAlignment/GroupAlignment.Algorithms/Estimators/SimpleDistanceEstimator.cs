// -----------------------------------------------------------------------
// <copyright file="SimpleDistanceEstimator.cs" company="JM">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace GroupAlignment.Algorithms.Estimators
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using GroupAlignment.Core.Models;

    /// <summary>
    /// Distance estimator class
    /// </summary>
    public class SimpleDistanceEstimator : AbstractDistanceEstimator
    {
        /// <summary>
        /// Gets simple distance estimate for 2 sequences
        /// </summary>
        /// <param name="sequence1">The sequence 1.</param>
        /// <param name="sequence2">The sequence 2.</param>
        /// <returns>Distance estimate</returns>
        public override int Distance(BaseSequence sequence1, BaseSequence sequence2)
        {
            var maxLength = Math.Max(sequence1.Count, sequence2.Count);
            sequence1 = BaseSequence.Complete(sequence1, maxLength);
            sequence2 = BaseSequence.Complete(sequence2, maxLength);
            var pairSequence = this.ToPair(sequence1, sequence2, (x, y) => new NucleotidePair(x, y));
            var res = pairSequence.Sum(pair => this.NucleotideDistance(pair.First, pair.Second));
            return res;
        }

        /// <summary>
        /// The distance.
        /// </summary>
        /// <param name="pair">The pair sequence.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public override int Distance(PairAlignment pair)
        {
            return pair.DynamicTable[new Pair(pair.Length, pair.Length)].Distance;
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="n1">The nucleotide 1.</param>
        /// <param name="n2">The nucleotide 2.</param>
        /// <returns>Distance estimate</returns>
        public override int NucleotideDistance(Nucleotide n1, Nucleotide n2)
        {
            return n1 == n2 ? 0 : 1;
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="pair">The nucleotide pair.</param>
        /// <returns>Distance estimate</returns>
        public override int NucleotideDistance(NucleotidePair pair)
        {
            return pair.First == pair.Second ? 0 : 1;
        }
    }
}
