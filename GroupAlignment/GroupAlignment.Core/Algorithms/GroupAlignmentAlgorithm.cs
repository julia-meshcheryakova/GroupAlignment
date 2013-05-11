
namespace GroupAlignment.Core.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Extensions;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;

    /// <summary>
    /// The dynamic pair alignment.
    /// </summary>
    public class GroupAlignmentAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupAlignmentAlgorithm"/> class.
        /// </summary>
        /// <param name="estimator">The estimator.</param>
        public GroupAlignmentAlgorithm(AbstractDistanceEstimator estimator)
        {
            this.Estimator = estimator;
            this.PairAlignmentAlgorithm = new PairAlignmentAlgorithm(estimator);
        }

        /// <summary>
        /// Gets or sets the estimator.
        /// </summary>
        public AbstractDistanceEstimator Estimator { get; set; }

        /// <summary>
        /// Gets or sets the estimator.
        /// </summary>
        public PairAlignmentAlgorithm PairAlignmentAlgorithm { get; set; }

        /// <summary>
        /// The generate method.
        /// </summary>
        /// <param name="alignment">The pair alignment.</param>
        public void FillPairAlignmentsMap(GroupAlignment alignment)
        {
            alignment.PairAlignmentsMap = this.GeneratePairAlignmentsMap(alignment);
            alignment.MinBound = alignment.PairAlignmentsMap.Values.Min(p => p.Distance);
            alignment.MaxBound = alignment.PairAlignmentsMap.Values.Max(p => p.Distance);
            alignment.AvgBound = alignment.PairAlignmentsMap.Values.Average(p => p.Distance);
        }

        /// <summary>
        /// The dynamic table fill.
        /// </summary>
        /// <param name="groupAlignment">The group alignment.</param>
        /// <returns>The dynamic table.</returns>
        private Dictionary<Index, PairAlignment> GeneratePairAlignmentsMap(GroupAlignment groupAlignment)
        {
            var map = new Dictionary<Index, PairAlignment>();
            foreach (var sequence in groupAlignment)
            {
                // except the diagonal elements and filled cells (the table is been filling for symmetrical elements in one step)
                foreach (var sequence2 in groupAlignment.Where(a => a.Id != sequence.Id && map[new Index(sequence.Id.Value, a.Id.Value)] == null))
                {
                    var p = new PairAlignment(sequence, sequence2);
                    this.PairAlignmentAlgorithm.FillAlignedSequences(p);
                    map[new Index(sequence.Id.Value, sequence2.Id.Value)] = p;
                    map[new Index(sequence2.Id.Value, sequence.Id.Value)] = p;
                }
            }

            return map;
        }
    }
}
