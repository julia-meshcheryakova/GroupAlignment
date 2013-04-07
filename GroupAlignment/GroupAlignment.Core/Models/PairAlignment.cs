
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

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
        /// Gets or sets first aligned sequence.
        /// </summary>
        public BaseSequence FirstAligned { get; set; }

        /// <summary>
        /// Gets or sets first aligned sequence.
        /// </summary>
        public BaseSequence SecondAligned { get; set; }

        /// <summary>
        /// Gets or sets aligned sequences.
        /// </summary>
        public List<NucleotidePair> Columns { get; set; }
    }
}