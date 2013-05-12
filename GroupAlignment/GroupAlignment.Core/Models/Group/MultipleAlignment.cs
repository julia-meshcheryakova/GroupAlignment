
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;
    using System.Linq;

    using global::GroupAlignment.Core.Estimators;
    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class MultipleAlignment : List<Sequence>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public MultipleAlignment(int? id)
        {
            this.Id = id ?? 0;
            //this.Sequences = new List<Sequence>();
            this.First = null;
            this.Second = null;
            this.AlignedSequences = new List<MultipleSequence>();
            this.ProfilesTable = new ProfilesTable();
            this.Size = 0;
            this.Diameter = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="sequences">The sequences list.</param>
        /// <param name="estimator">The estimator.</param>
        public MultipleAlignment(int? id, IEnumerable<Sequence> sequences, AbstractDistanceEstimator estimator)
            : this(id)
        {
            var list = sequences.ToList();
            this.AddRange(list);
            //this.Sequences = list;
            var multipleSequence = new MultipleSequence(list);
            this.AlignedSequences.AddRange(new[] { multipleSequence });
            this.Size = Extensions.ToPair(list, list, estimator.Distance).Sum() / 2;
            this.Diameter = Extensions.ToPair(list, list, estimator.Distance).Max();
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        ///// </summary>
        ///// <param name="sequences">The sequences list.</param>
        ///// <param name="parent1">The parent 1.</param>
        ///// <param name="parent2">The parent 2.</param>
        //public MultipleAlignment(IEnumerable<Sequence> sequences, MultipleAlignment parent1, MultipleAlignment parent2)
        //    : this()
        //{
        //    this.Sequences = sequences.ToList();
        //    this.First = parent1;
        //    this.Second = parent2;
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignment"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="parent1">The parent 1.</param>
        /// <param name="parent2">The parent 2.</param>
        public MultipleAlignment(int? id, MultipleAlignment parent1, MultipleAlignment parent2)
            : this(id)
        {
            this.First = parent1;
            this.Second = parent2;
            this.AddRange(parent1);
            this.AddRange(parent2);
            //this.Sequences.AddRange(parent1.Sequences);
            //this.Sequences.AddRange(parent2.Sequences);
        }

        /// <summary>
        /// Gets or sets the identifier of sequence
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        //public List<Sequence> Sequences { get; set; }

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
        /// Gets or sets the size of alignment - sum of distances between sequences.
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Gets or sets the diameter of alignment - max distance between sequences in alignment.
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Gets the profiles for aligned sequences.
        /// </summary>
        public List<Profile> Profiles
        {
            get
            {
                var profiles = new List<Profile>();
                for (var i = 0; i < this.AlignedSequences.Count; i++)
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