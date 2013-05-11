
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    using GroupAlignment.Core.Extensions;

    /// <summary>
    /// The profile item.
    /// </summary>
    public class ProfileItem : Dictionary<Nucleotide, double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileItem"/> class.
        /// </summary>
        public ProfileItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileItem"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public ProfileItem(Dictionary<Nucleotide, double> dictionary)
        {
            this.AddRange(dictionary);
        }
    }
}
