
namespace GroupAlignment.Core.Models
{
    using System;

    /// <summary>
    /// Pair of nucleotides
    /// </summary>
    public class NucleotidePair : IEquatable<NucleotidePair>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NucleotidePair"/> class.
        /// </summary>
        /// <param name="first">The first nucleotide.</param>
        /// <param name="second">The second nucleotide.</param>
        public NucleotidePair(Nucleotide first, Nucleotide second)
        {
            this.First = first;
            this.Second = second;
        }

        /// <summary>
        /// Gets or sets the first nucleotide.
        /// </summary>
        public Nucleotide First { get; set; }

        /// <summary>
        /// Gets or sets the second nucleotide.
        /// </summary>
        public Nucleotide Second { get; set; }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public override int GetHashCode()
        {
            return ((int)this.First * 17) + (int)this.Second;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as NucleotidePair);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">The other pair.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Equals(NucleotidePair other)
        {
            return this.First == other.First && this.Second == other.Second;
        }
    }
}