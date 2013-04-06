
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class BaseAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAlignment"/> class.
        /// </summary>
        /// <param name="sequences">The sequences.</param>
        public BaseAlignment(List<BaseSequence> sequences)
        {
            this.Sequences = sequences;
        }

        /// <summary>
        /// Gets or sets original sequences.
        /// </summary>
        public List<BaseSequence> Sequences { get; set; }

        /// <summary>
        /// Gets or sets aligned sequences.
        /// </summary>
        public List<BaseSequence> AlignedSequences { get; set; }

        /// <summary>
        /// Gets or sets columns.
        /// </summary>
        public List<BaseColumn> Columns { get; set; }
    }
}