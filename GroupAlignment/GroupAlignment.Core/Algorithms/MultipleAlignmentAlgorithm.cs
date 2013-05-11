
namespace GroupAlignment.Core.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Extensions;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;

    /// <summary>
    /// The multiple alignment algorithm - aligns two multiple alignments.
    /// </summary>
    public class MultipleAlignmentAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAlignmentAlgorithm"/> class.
        /// </summary>
        /// <param name="estimator">The estimator.</param>
        public MultipleAlignmentAlgorithm(AbstractDistanceEstimator estimator)
        {
            this.Estimator = estimator;
        }

        /// <summary>
        /// Gets or sets the estimator.
        /// </summary>
        public AbstractDistanceEstimator Estimator { get; set; }

        /// <summary>
        /// The generate method.
        /// </summary>
        /// <param name="alignment">The multiple alignment.</param>
        public void FillAlignedSequences(MultipleAlignment alignment)
        {
            alignment.AlignedSequences = this.GenerateAlignedSequences(alignment);
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The aligned sequence variants.</returns>
        public List<MultipleSequence> GenerateAlignedSequences(MultipleAlignment alignment)
        {
            if (alignment.ProfilesTable.Count == 0)
            {
                this.FillProfilesTable(alignment);
            }

            var minDistance =
                alignment.ProfilesTable.Min(p => p.Value[new Index(p.Value.First.Count, p.Value.Second.Count)].Distance);

            var optimalDynamicTables =
                alignment.ProfilesTable.Where(
                    p => p.Value[new Index(p.Value.First.Count, p.Value.Second.Count)].Distance.AreEqual(minDistance)).Select(item => item.Value).ToList();

            return (from table in optimalDynamicTables
                    let ways = this.GenerateGraphWays(table)
                    from way in ways
                    select this.GenerateAlignedSequence(alignment, table, way)).ToList();
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <param name="table">The dynamic table.</param>
        /// <param name="way">The way in dynamic table</param>
        /// <returns>The aligned sequence variants.</returns>
        public MultipleSequence GenerateAlignedSequence(MultipleAlignment alignment, ProfileTableItem table, List<Index> way)
        {
            var sequence = new MultipleSequence();
            for (var i = 1; i < way.Count; ++i)
            {
                var pred = way[i - 1];
                var cur = way[i];
                if (pred.Item1.Equals(cur.Item1))
                {
                    var secondSequence = alignment.Second.AlignedSequences[table.Second.Id];
                    sequence.Add(new Column(Column.GetClearColumn(table.First.Count), secondSequence[cur.Item2]));
                }
                else if (pred.Item2.Equals(cur.Item2))
                {
                    var firstSequence = alignment.First.AlignedSequences[table.First.Id];
                    sequence.Add(new Column(firstSequence[cur.Item1], Column.GetClearColumn(table.Second.Count)));
                }
                else
                {
                    var firstSequence = alignment.First.AlignedSequences[table.First.Id];
                    var secondSequence = alignment.Second.AlignedSequences[table.Second.Id];
                    sequence.Add(new Column(firstSequence[cur.Item1], secondSequence[cur.Item2]));
                }
            }

            return sequence;
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="dynamicTable">The dynamic table.</param>
        /// <returns>The aligned sequence variants.</returns>
        public List<List<Index>> GenerateGraphWays(ProfileTableItem dynamicTable)
        {
            // fill variants
            var ways = new List<List<Index>>();
            ways.Add(new List<Index> { new Index(dynamicTable.First.Count, dynamicTable.Second.Count) });
            while (ways.Any(l => (l.First().Item1 as int?) != 0 && (l.First().Item2 as int?) != 0))
            {
                var waysCopy = new List<List<Index>>();
                foreach (var way in ways.Where(l => (l.First().Item1 as int?) != 0 && (l.First().Item2 as int?) != 0))
                {
                    var pair = way.First();
                    var predecessors = dynamicTable[pair].Predecessors;
                    var newWays = new List<List<Index>> { way };
                    for (var i = 1; i < predecessors.Count; ++i)
                    {
                        newWays.Add(new List<Index>(way));
                    }

                    for (var i = 0; i < predecessors.Count; ++i)
                    {
                        newWays[i].Insert(0, predecessors[i]);
                    }

                    waysCopy.AddRange(newWays);
                }

                ways = waysCopy;
            }

            return ways;
        }

        /// <summary>
        /// The generate method.
        /// </summary>
        /// <param name="alignment">The pair alignment.</param>
        public void FillProfilesTable(MultipleAlignment alignment)
        {
            var firstProfiles = alignment.First.Profiles;
            var secondProfiles = alignment.Second.Profiles;
            alignment.ProfilesTable = new ProfilesTable();
            for (var i = 0; i < firstProfiles.Count; ++i)
            {
                for (var j = 0; j < secondProfiles.Count; ++j)
                {
                    alignment.ProfilesTable.Add(new Index(i, j), this.GenerateDynamicTable(firstProfiles[i], secondProfiles[j]));
                }   
            }
        }

        /// <summary>
        /// The dynamic table generation.
        /// </summary>
        /// <param name="first">The first sequence.</param>
        /// <param name="second">The second sequence.</param>
        /// <returns>The dynamic table.</returns>
        private ProfileTableItem GenerateDynamicTable(Profile first, Profile second)
        {
            var length1 = first.Count + 1;
            var length2 = second.Count + 1;
            var dynamicTable = new ProfileTableItem(first, second)
                {
                    { new Index(0, 0), new DynamicTableItem(0, new List<Index>()) }
                };

            // first row set
            for (var i = 1; i < length2; i++)
            {
                dynamicTable.Add(new Index(0, i), new DynamicTableItem(i * this.Estimator.ProfileItemNucleotideDistance(second[i], Nucleotide._), new List<Index> { new Index(0, i - 1) }));
            }

            // first column set
            for (var i = 1; i < length1; i++)
            {
                dynamicTable.Add(new Index(i, 0), new DynamicTableItem(i * this.Estimator.ProfileItemNucleotideDistance(first[i], Nucleotide._), new List<Index> { new Index(i - 1, 0) }));
            }

            for (var i = 1; i < length1; i++)
            {
                for (var j = 1; j < length2; j++)
                {
                    var pj = new Index(i - 1, j); // same column
                    var pi = new Index(i, j - 1); // same row
                    var pij = new Index(i - 1, j - 1);
                    var estimates = new Dictionary<Index, double>
                        {
                            { pj, dynamicTable[pj].Distance + this.Estimator.ProfileItemNucleotideDistance(first[i], Nucleotide._) },
                            { pi, dynamicTable[pi].Distance + this.Estimator.ProfileItemNucleotideDistance(Nucleotide._, second[j]) },
                            {
                                pij,
                                dynamicTable[pij].Distance + this.Estimator.ProfileItemsDistance(first[i], second[j])
                            }
                        };

                    var d = estimates.Values.Min();
                    var dynamicTableItem = new DynamicTableItem(d, estimates.Where(e => e.Value.AreEqual(d)).Select(e => e.Key).ToList());
                    dynamicTable.Add(new Index(i, j), dynamicTableItem);
                }
            }

            return dynamicTable;
        }
    }
}
