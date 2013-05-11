
namespace GroupAlignment.Core.Models
{
    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class Sequence : BaseSequence
    {
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
    }
}
