
namespace GroupAlignment.Core.Estimators
{
    using System;
    using System.Linq;

    using GroupAlignment.Core.Extensions;
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
        public override double Distance(Sequence sequence1, Sequence sequence2)
        {
            var maxLength = Math.Max(sequence1.Count, sequence2.Count);
            sequence1 = Sequence.Complete(sequence1, maxLength);
            sequence2 = Sequence.Complete(sequence2, maxLength);
            var pairSequence = this.ToPair(sequence1, sequence2, (x, y) => new NucleotidePair(x, y));
            var res = pairSequence.Sum(pair => this.NucleotideDistance(pair.First, pair.Second));
            return res;
        }

        /// <summary>
        /// The distance.
        /// </summary>
        /// <param name="pair">The pair sequence.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public override double Distance(PairAlignment pair)
        {
            return pair.DynamicTable[new Index(pair.First.Count, pair.Second.Count)].Distance;
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="n1">The nucleotide 1.</param>
        /// <param name="n2">The nucleotide 2.</param>
        /// <returns>Distance estimate</returns>
        public override double NucleotideDistance(Nucleotide n1, Nucleotide n2)
        {
            return n1 == n2 ? 0 : 1;
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="pair">The nucleotide pair.</param>
        /// <returns>Distance estimate</returns>
        public override double NucleotideDistance(NucleotidePair pair)
        {
            return pair.First == pair.Second ? 0 : 1;
        }
    }
}
