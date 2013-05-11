
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;
    using System.Linq;

    using global::GroupAlignment.Core.Extensions;

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
        /// <param name="parent1">The parent 1.</param>
        /// <param name="parent2">The parent 2.</param>
        public MultipleAlignment(IEnumerable<BaseSequence> sequences, MultipleAlignment parent1 = null, MultipleAlignment parent2 = null)
        {
            this.Sequences = sequences.ToList();
            this.Parent1 = parent1;
            this.Parent2 = parent2;
            this.Ways = new List<List<Index>>();
            this.AlignedSequences = new List<MultipleSequence>();
        }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public List<BaseSequence> Sequences { get; set; }

        /// <summary>
        /// Gets or sets the parent 1.
        /// </summary>
        public MultipleAlignment Parent1 { get; set; }

        /// <summary>
        /// Gets or sets the parent 2.
        /// </summary>
        public MultipleAlignment Parent2 { get; set; }

        /// <summary>
        /// Gets or sets the distance dynamic table for pair of multiple alignments (profiles alignment).
        /// </summary>
        public Dictionary<Index, DynamicTableItem> DynamicTable { get; set; }

        /// <summary>
        /// Gets or sets ways of alignment if dynamic table.
        /// </summary>
        public List<List<Index>> Ways { get; set; }

        /// <summary>
        /// Gets or sets variants of sequences alignments.
        /// </summary>
        public List<MultipleSequence> AlignedSequences { get; set; }

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
    }
}