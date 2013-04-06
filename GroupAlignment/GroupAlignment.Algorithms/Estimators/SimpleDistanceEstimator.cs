// -----------------------------------------------------------------------
// <copyright file="SimpleDistanceEstimator.cs" company="JM">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace GroupAlignment.Algorithms.Estimators
{
    using System;
    using System.Linq;

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
            this.CompleteSequence(sequence1, maxLength);
            this.CompleteSequence(sequence2, maxLength);
            var pairSequence = this.ToPair(sequence1, sequence2, (x, y) => new { nucl1 = x, nucl2 = y });
            var res = pairSequence.Sum(pair => this.NucleotideDistance(pair.nucl1, pair.nucl2));
            return res;
            ///// sequence1.Value.Sum((n, i) =>  sequence2.Value[i])
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
    }
}
