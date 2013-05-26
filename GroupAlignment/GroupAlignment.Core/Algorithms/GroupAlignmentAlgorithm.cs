
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
            this.MultipleAlignmentAlgorithm = new MultipleAlignmentAlgorithm(estimator);
        }

        /// <summary>
        /// Gets or sets the estimator.
        /// </summary>
        public AbstractDistanceEstimator Estimator { get; set; }

        /// <summary>
        /// Gets or sets the pair alignment algorithm.
        /// </summary>
        public PairAlignmentAlgorithm PairAlignmentAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the multiple alignment algorithm.
        /// </summary>
        public MultipleAlignmentAlgorithm MultipleAlignmentAlgorithm { get; set; }

        /// <summary>
        /// The condensate process - groups sequences into many multiple alignments.
        /// </summary>
        /// <param name="alignment">The group alignment.</param>
        public void Condensate(GroupAlignment alignment)
        {
            this.InitializeCondensateMap(alignment);
            while (alignment.Groups.Count > 1)
            {
                this.CondensateStep(alignment);
            }
        }

        /// <summary>
        /// The generate method.
        /// </summary>
        /// <param name="alignment">The pair alignment.</param>
        public void InitializeGroups(GroupAlignment alignment)
        {
            alignment.Groups = alignment.Select(s => new MultipleAlignment(s.Id, new[] { s }, this.Estimator)).ToList();
            alignment.AllGroups.AddRange(alignment.Groups);
            alignment.GroupsCounter = alignment.Groups.Max(g => g.Id) + 1;
        }

        /// <summary>
        /// The step of condensate method.
        /// </summary>
        /// <param name="alignment">The pair alignment.</param>
        public void CondensateStep(GroupAlignment alignment)
        {
            var newGroup =
                alignment.CondensateMap.OrderBy(item => item.Value.Diameter)
                         .ThenBy(item => item.Value.Size)
                         .ThenBy(item => item.Value.Id)
                         .First().Value;
            
            alignment.Groups.Remove(newGroup.First);
            alignment.Groups.Remove(newGroup.Second);
            alignment.Groups.Add(newGroup);
            alignment.AllGroups.Add(newGroup);

            this.UpdateCondensateMap(alignment, newGroup);
        }

        /// <summary>
        /// The dynamic table fill.
        /// </summary>
        /// <param name="alignment">The group alignment.</param>
        public void InitializeCondensateMap(GroupAlignment alignment)
        {
            if (alignment.PairAlignmentsMap == null || !alignment.PairAlignmentsMap.Any())
            {
                this.FillPairAlignmentsMap(alignment);
            }

            if (alignment.Groups == null || !alignment.Groups.Any())
            {
                this.InitializeGroups(alignment);
            }

            var map = new Dictionary<Index, MultipleAlignment>();
            foreach (var group1 in alignment.Groups)
            {
                // except the diagonal elements and filled cells (the table is been filling for symmetrical elements in one step)
                foreach (var group2 in alignment.Groups.Where(a => a.Id != group1.Id && !map.ContainsKey(new Index(group1.Id, a.Id))))
                {
                    var m = new MultipleAlignment(alignment.GroupsCounter, group1, group2);
                    alignment.GroupsCounter++;
                    this.MultipleAlignmentAlgorithm.FillAlignedSequences(m, alignment.PairAlignmentsMap);
                    map[new Index(group1.Id, group2.Id)] = m;
                    map[new Index(group2.Id, group1.Id)] = m;
                }
            }

            alignment.CondensateMap = map;
        }

        /// <summary>
        /// The dynamic table fill.
        /// </summary>
        /// <param name="alignment">The group alignment.</param>
        /// <param name="newGroup">The new group.</param>
        public void UpdateCondensateMap(GroupAlignment alignment, MultipleAlignment newGroup)
        {
            // clean parent elements from condensate map
            var removed = alignment.CondensateMap
                .Where(item => item.Key.Item1 == newGroup.First.Id || item.Key.Item2 == newGroup.First.Id ||
                               item.Key.Item1 == newGroup.Second.Id || item.Key.Item2 == newGroup.Second.Id)
                .ToList();
            foreach (var keyValuePair in removed)
            {
                alignment.CondensateMap.Remove(keyValuePair.Key);
            }

            // except the diagonal element
            foreach (var group1 in alignment.Groups.Where(a => a.Id != newGroup.Id))
            {
                MultipleAlignment m;
                if (group1.Diameter < newGroup.Diameter
                    || (group1.Diameter == newGroup.Diameter && group1.Size < newGroup.Size))
                {
                    m = new MultipleAlignment(alignment.GroupsCounter, group1, newGroup);
                }
                else
                {
                    m = new MultipleAlignment(alignment.GroupsCounter, newGroup, group1);
                }

                alignment.GroupsCounter++;
                this.MultipleAlignmentAlgorithm.FillAlignedSequences(m, alignment.PairAlignmentsMap);
                alignment.CondensateMap[new Index(group1.Id, newGroup.Id)] = m;
                alignment.CondensateMap[new Index(newGroup.Id, group1.Id)] = m;
            }
        }

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
        /// <param name="sequences">The group alignment.</param>
        /// <returns>The dynamic table.</returns>
        public Dictionary<Index, PairAlignment> GeneratePairAlignmentsMap(IEnumerable<Sequence> sequences)
        {
            var map = new Dictionary<Index, PairAlignment>();
            var list = sequences.ToList();
            foreach (var sequence in list)
            {
                // except the diagonal elements and filled cells (the table is been filling for symmetrical elements in one step)
                foreach (var sequence2 in list.Where(a => a.Id != sequence.Id && !map.ContainsKey(new Index(sequence.Id.Value, a.Id.Value))))
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
