
namespace GroupAlignment.Core.Models.Pair
{
    using System.Collections.Generic;

    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class PairSequence : List<NucleotidePair>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairSequence"/> class.
        /// </summary>
        public PairSequence()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PairSequence"/> class.
        /// </summary>
        /// <param name="list">The list of nucleotide pairs.</param>
        public PairSequence(IEnumerable<NucleotidePair> list)
        {
            this.AddRange(list);
        }
    }
}