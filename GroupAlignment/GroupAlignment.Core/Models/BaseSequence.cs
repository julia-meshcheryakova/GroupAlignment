
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class BaseSequence : List<Nucleotide>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSequence"/> class.
        /// </summary>
        public BaseSequence()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSequence"/> class.
        /// </summary>
        /// <param name="list">The list of nucleotides.</param>
        public BaseSequence(IEnumerable<Nucleotide> list)
        {
            this.AddRange(list);
        }

        /// <summary>
        /// The indexer override.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="Nucleotide?"/>.
        /// </returns>
        public new Nucleotide this[int index]
        {
            get
            {
                return index > this.Count || index <= 0 ? Nucleotide._ : base[index - 1];
            }
        }

        /// <summary>
        /// Completes sequence to the certain length
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="count">The count.</param>
        /// <returns>The completed<see cref="BaseSequence"/>.</returns>
        public static BaseSequence Complete(BaseSequence sequence, int count)
        {
            var completedSequence = new BaseSequence(sequence);
            var length = sequence.Count;
            if (length >= count)
            {
                return completedSequence;
            }

            for (var i = 0; i < count - length; ++i)
            {
                completedSequence.Add(Nucleotide._);
            }

            return completedSequence;
        }
    }
}