
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;
    using System.Web.UI;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class PairAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairAlignment"/> class.
        /// </summary>
        public PairAlignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PairAlignment"/> class.
        /// </summary>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        public PairAlignment(BaseSequence sequence1, BaseSequence sequence2)
        {
            this.First = sequence1;
            this.Second = sequence2;
            this.Ways = new List<List<Pair>>();
            this.AlignedSequences = new List<PairSequence>();
            this.DynamicTable = new Dictionary<Pair, DynamicTableItem>();
        }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public BaseSequence First { get; set; }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public BaseSequence Second { get; set; }

        /// <summary>
        /// Gets or sets the distance dynamic table.
        /// </summary>
        public Dictionary<Pair, DynamicTableItem> DynamicTable { get; set; }

        /// <summary>
        /// Gets or sets ways of alignment if dynamic table.
        /// </summary>
        public List<List<Pair>> Ways { get; set; }

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
                return this.First.Count;
            }
        }
    }
}