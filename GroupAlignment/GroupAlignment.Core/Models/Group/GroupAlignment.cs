
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;
    using System.Linq;

    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class GroupAlignment : List<Sequence>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupAlignment"/> class.
        /// </summary>
        public GroupAlignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupAlignment"/> class.
        /// </summary>
        /// <param name="sequences">The list of nucleotide sequences.</param>
        /// <param name="generateIds">Flag if id for sequences need to be generated</param>
        public GroupAlignment(IEnumerable<Sequence> sequences, bool generateIds = false)
        {
            var list = sequences.ToList();
            if (generateIds)
            {
                for (var i = 0; i < list.Count(); i++)
                {
                    list[i].Id = i + 1;
                }
            }

            this.AddRange(list);
            Groups = new List<MultipleAlignment>();
        }

        /// <summary>
        /// Gets or sets the groups counter.
        /// </summary>
        public int GroupsCounter { get; set; }

        /// <summary>
        /// Gets or sets the pair alignments table.
        /// </summary>
        public Dictionary<Index, PairAlignment> PairAlignmentsMap { get; set; }

        /// <summary>
        /// Gets or sets the multiple alignments condensate map.
        /// </summary>
        public Dictionary<Index, MultipleAlignment> CondensateMap { get; set; }

        /// <summary>
        /// Gets or sets the min distance.
        /// </summary>
        public double MinBound { get; set; }

        /// <summary>
        /// Gets or sets the max distance.
        /// </summary>
        public double MaxBound { get; set; }

        /// <summary>
        /// Gets or sets the average distance.
        /// </summary>
        public double AvgBound { get; set; }

        /// <summary>
        /// Gets the average distance calculate from min and max.
        /// </summary>
        public double Avg2Bound
        {
            get
            {
                return (this.MinBound + this.MaxBound) / 2.0;
            }
        }

        /// <summary>
        /// Gets or sets aligned sequences.
        /// </summary>
        public List<MultipleAlignment> Groups { get; set; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length
        {
            get
            {
                return this.First().Count;
            }
        }
    }
}