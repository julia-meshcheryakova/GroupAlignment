
namespace GroupAlignment.Core.Models
{
    /// <summary>
    /// Type of nucleotide.
    /// A - adenine
    /// C - cytosine
    /// G - guanine
    /// T - thymine
    /// </summary>
    public enum Nucleotide
    {
        /// <summary>
        /// Unknown symbol
        /// </summary>
        N = 0x1,

        /// <summary>
        /// A - adenine
        /// </summary>
        A,

        /// <summary>
        /// C - cytosine
        /// </summary>
        C,

        /// <summary>
        /// G - guanine
        /// </summary>
        G,

        /// <summary>
        /// T - thymine
        /// </summary>
        T,

        /// <summary>
        /// _ - space, means clear symbol
        /// </summary>
        _
    }
}
