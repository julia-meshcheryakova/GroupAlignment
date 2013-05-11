
namespace GroupAlignment.Core.Models.Group
{
    using System;
    using System.Collections.Generic;

    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// The profile item.
    /// </summary>
    public class ProfileItem : Dictionary<Nucleotide, double>, IEquatable<ProfileItem>
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
        public ProfileItem(IEnumerable<KeyValuePair<Nucleotide, double>> dictionary)
        {
            this.AddRange(dictionary);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Profile);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">The other pair.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Equals(ProfileItem other)
        {
            return true;
        }
    }
}
