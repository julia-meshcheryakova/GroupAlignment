
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;
    using System.Linq;

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
        /// Gets the profile.
        /// </summary>
        public List<ProfileItem> Profile
        {
            get
            {
                var profile = new List<ProfileItem>();
                for (var i = 1; i <= this.Count; ++i)
                {
                    var column = this[i];
                    profile.Add(column.ColumnProfile);
                }

                // TODO: check if that is the same
                var profile2 = this.Select(column => column.ColumnProfile).ToList();
                var useLinq = profile.Equals(profile2);

                return profile;
            }
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