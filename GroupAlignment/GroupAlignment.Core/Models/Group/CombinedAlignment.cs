
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Extentions;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class CombinedAlignment : List<BaseSequence>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedAlignment"/> class.
        /// </summary>
        public CombinedAlignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedAlignment"/> class.
        /// </summary>
        /// <param name="list">The list of nucleotide pairs.</param>
        public CombinedAlignment(IEnumerable<BaseSequence> list)
        {
            this.AddRange(list);
        }

        /// <summary>
        /// Gets or sets the pair alignments table.
        /// </summary>
        public Dictionary<Index, PairAlignment> PairAlignmentsTable { get; set; }

        /// <summary>
        /// Gets or sets aligned sequences.
        /// </summary>
        public List<BaseSequence> AlignedSequences { get; set; }

        /// <summary>
        /// Gets or sets columns.
        /// </summary>
        public List<BaseColumn> Columns { get; set; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length
        {
            get
            {
                return this.First().Count;
            }
        }

        /// <summary>
        /// The indexer override.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Nucleotide"/>.</returns>
        public new BaseSequence this[int index]
        {
            get
            {
                return index > this.Count || index <= 0 ? null : base[index - 1];
            }
        }
    }
}