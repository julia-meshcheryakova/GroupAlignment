
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;

    /// <summary>
    /// The profile item.
    /// </summary>
    public class Profile : List<ProfileItem>
    {
        /// <summary>
        /// The indexer override.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Nucleotide"/>.</returns>
        public new ProfileItem this[int index]
        {
            get
            {
                return index > this.Count || index <= 0 ? null : base[index - 1];
            }
        }
    }
}
