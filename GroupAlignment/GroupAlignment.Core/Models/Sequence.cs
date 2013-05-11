
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class Sequence : List<Nucleotide>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence"/> class.
        /// </summary>
        public Sequence()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence"/> class.
        /// </summary>
        /// <param name="list">The list of nucleotides.</param>
        /// <param name="id">The id.</param>
        public Sequence(IEnumerable<Nucleotide> list, int? id = null)
        {
            this.AddRange(list);
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier of sequence
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the chain
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the chain
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Organism record ID
        /// </summary>
        public int? OrganismId { get; set; }

        /// <summary>
        /// Completes sequence to the certain length
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="count">The count.</param>
        /// <returns>The completed<see cref="Sequence"/>.</returns>
        public static Sequence Complete(Sequence sequence, int count)
        {
            var completedSequence = new Sequence(sequence);
            var length = sequence.Count;
            if (length >= count)
            {
                return completedSequence;
            }

            for (var i = 0; i < count - length; i++)
            {
                completedSequence.Add(Nucleotide._);
            }

            return completedSequence;
        }
    }
}
