
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Extentions;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class MultipleAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        public MultipleAlignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        /// <param name="sequences">The sequences list.</param>
        public MultipleAlignment(IEnumerable<BaseSequence> sequences)
        {
            this.Sequences = sequences.ToList();
            this.Ways = new List<List<Index>>();
            this.AlignedSequences = new List<PairSequence>();
            this.DynamicTable = new Dictionary<Index, DynamicTableItem>();
        }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public List<BaseSequence> Sequences { get; set; }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public BaseSequence Second { get; set; }

        /// <summary>
        /// Gets or sets the distance dynamic table.
        /// </summary>
        public Dictionary<Index, DynamicTableItem> DynamicTable { get; set; }

        /// <summary>
        /// Gets or sets ways of alignment if dynamic table.
        /// </summary>
        public List<List<Index>> Ways { get; set; }

        /// <summary>
        /// Gets or sets variants of sequences alignments.
        /// </summary>
        public List<PairSequence> AlignedSequences { get; set; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length
        {
            get
            {
                return this.Sequences.First().Count;
            }
        }

        /// <summary>
        /// Gets or sets aligned sequences.
        /// </summary>
        //public List<BaseSequence> AlignedSequences { get; set; }

        /// <summary>
        /// Gets or sets columns.
        /// </summary>
        public List<BaseColumn> Columns { get; set; }
    }
}