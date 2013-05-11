
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;
    using System.Linq;

    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class MultipleAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        public MultipleAlignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        /// <param name="sequences">The sequences list.</param>
        /// <param name="parent1">The parent 1.</param>
        /// <param name="parent2">The parent 2.</param>
        public MultipleAlignment(IEnumerable<Sequence> sequences, MultipleAlignment parent1 = null, MultipleAlignment parent2 = null)
        {
            this.Sequences = sequences.ToList();
            this.First = parent1;
            this.Second = parent2;
            this.AlignedSequences = new List<MultipleSequence>();
        }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public List<Sequence> Sequences { get; set; }

        /// <summary>
        /// Gets or sets the parent 1.
        /// </summary>
        public MultipleAlignment First { get; set; }

        /// <summary>
        /// Gets or sets the parent 2.
        /// </summary>
        public MultipleAlignment Second { get; set; }

        /// <summary>
        /// Gets or sets the profiles alignments table for pair of multiple alignments (profiles alignment).
        /// </summary>
        public ProfilesTable ProfilesTable { get; set; }

        /// <summary>
        /// Gets or sets variants of sequences alignments.
        /// </summary>
        public List<MultipleSequence> AlignedSequences { get; set; }

        /// <summary>
        /// Gets the profiles for aligned sequences.
        /// </summary>
        public List<Profile> Profiles
        {
            get
            {
                var profiles = new List<Profile>();
                for (var i = 0; i < this.AlignedSequences.Count; ++i)
                {
                    var profile = this.AlignedSequences[i].Profile;
                    profile.Id = i;
                    profiles.Add(profile);
                }

                return profiles;
            }
        }
    }
}