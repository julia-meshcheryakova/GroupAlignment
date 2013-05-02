
namespace GroupAlignment.Core.Models
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

        /// <summary>
        /// The indexer override.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Nucleotide"/>.</returns>
        public new NucleotidePair this[int index]
        {
            get
            {
                return index > this.Count || index <= 0 ? new NucleotidePair(Nucleotide._, Nucleotide._) : base[index - 1];
            }
        }
    }
}