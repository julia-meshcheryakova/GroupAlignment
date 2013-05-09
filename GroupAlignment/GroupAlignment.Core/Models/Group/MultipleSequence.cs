
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class MultipleSequence : List<Column>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSequence"/> class.
        /// </summary>
        public MultipleSequence()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSequence"/> class.
        /// </summary>
        /// <param name="list">The list of nucleotide pairs.</param>
        public MultipleSequence(IEnumerable<Column> list)
        {
            this.AddRange(list);
        }

        /// <summary>
        /// The indexer override.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Nucleotide"/>.</returns>
        public new Column this[int index]
        {
            get
            {
                return index > this.Count || index <= 0 ? null : base[index - 1];
            }
        }
    }
}