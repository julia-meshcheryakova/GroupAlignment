
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class BaseSequence
    {
        /// <summary>
        /// Gets or sets the chain of nucleotides
        /// TODO: List of enumeration ?
        /// </summary>
        public List<Nucleotide> Value { get; set; }
    }
}
