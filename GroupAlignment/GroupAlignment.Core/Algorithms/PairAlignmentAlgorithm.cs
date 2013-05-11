
namespace GroupAlignment.Core.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Extensions;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Pair;

    /// <summary>
    /// The dynamic pair alignment.
    /// </summary>
    public class PairAlignmentAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairAlignmentAlgorithm"/> class.
        /// </summary>
        /// <param name="estimator">The estimator.</param>
        public PairAlignmentAlgorithm(AbstractDistanceEstimator estimator)
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
        /// <param name="alignment">The pair alignment.</param>
        public void FillAlignedSequences(PairAlignment alignment)
        {
            alignment.AlignedSequences = this.GenerateAlignedSequences(alignment);
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The aligned sequence variants.</returns>
        public List<PairSequence> GenerateAlignedSequences(PairAlignment alignment)
        {
            this.FillGraphWays(alignment);

            var sequences = new List<PairSequence>();
            foreach (var way in alignment.Ways)
            {
                var sequence = new PairSequence();
                for (var i = 1; i < way.Count; i++)
                {
                    var pred = way[i - 1];
                    var cur = way[i];
                    var ii = cur.Item1 - 1; // in sequence
                    var jj = cur.Item2 - 1; // in sequence
                    if (pred.Item1.Equals(cur.Item1))
                    {
                        sequence.Add(new NucleotidePair(Nucleotide._, alignment.Second[jj]));
                    }
                    else if (pred.Item2.Equals(cur.Item2))
                    {
                        sequence.Add(new NucleotidePair(alignment.First[ii], Nucleotide._));
                    }
                    else
                    {
                        sequence.Add(new NucleotidePair(alignment.First[ii], alignment.Second[jj]));
                    }
                }

                sequences.Add(sequence);
            }

            return sequences;
        }

        /// <summary>
        /// Fills graph ways.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        public void FillGraphWays(PairAlignment alignment)
        {
            alignment.Ways = this.GenerateGraphWays(alignment);
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The aligned sequence variants.</returns>
        public List<List<Index>> GenerateGraphWays(PairAlignment alignment)
        {
            if (alignment.DynamicTable.Count == 0)
            {
                this.FillDynamic(alignment);
            }

            // fill variants
            var ways = new List<List<Index>>();
            ways.Add(new List<Index> { new Index(alignment.First.Count, alignment.Second.Count) });
            while (ways.Any(l => (l.First().Item1 as int?) != 0 && (l.First().Item2 as int?) != 0))
            {
                var waysCopy = new List<List<Index>>();
                foreach (var way in ways.Where(l => (l.First().Item1 as int?) != 0 && (l.First().Item2 as int?) != 0))
                {
                    var pair = way.First();
                    var predecessors = alignment.DynamicTable[pair].Predecessors;
                    var newWays = new List<List<Index>> { way };
                    for (var i = 1; i < predecessors.Count; i++)
                    {
                        newWays.Add(new List<Index>(way));
                    }

                    for (var i = 0; i < predecessors.Count; i++)
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
        public void FillDynamic(PairAlignment alignment)
        {
            alignment.DynamicTable = this.GenerateDynamicTable(alignment);
        }

        /// <summary>
        /// The dynamic table fill.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The dynamic table.</returns>
        private DynamicTable GenerateDynamicTable(PairAlignment alignment)
        {
            var length1 = alignment.First.Count + 1;
            var length2 = alignment.Second.Count + 1;
            var dynamicTable = new DynamicTable
                {
                    { new Index(0, 0), new DynamicTableItem(0, new List<Index>()) }
                };

            // first row set
            for (var i = 1; i < length2; i++)
            {
                var ii = i - 1; // in sequence
                dynamicTable.Add(new Index(0, i), new DynamicTableItem(i * this.Estimator.NucleotideDistance(alignment.Second[ii], Nucleotide._), new List<Index> { new Index(0, i - 1) }));
            }

            // first column set
            for (var i = 1; i < length1; i++)
            {
                var ii = i - 1; // in sequence
                dynamicTable.Add(new Index(i, 0), new DynamicTableItem(i * this.Estimator.NucleotideDistance(alignment.First[ii], Nucleotide._), new List<Index> { new Index(i - 1, 0) }));
            }

            for (var i = 1; i < length1; i++)
            {
                for (var j = 1; j < length2; j++)
                {
                    var pj = new Index(i - 1, j); // same column
                    var pi = new Index(i, j - 1); // same row
                    var pij = new Index(i - 1, j - 1);
                    var ii = i - 1; // in sequence
                    var jj = j - 1; // in sequence
                    var estimates = new Dictionary<Index, double>
                        {
                            { pj, dynamicTable[pj].Distance + this.Estimator.NucleotideDistance(alignment.First[ii], Nucleotide._) },
                            { pi, dynamicTable[pi].Distance + this.Estimator.NucleotideDistance(Nucleotide._, alignment.Second[jj]) },
                            {
                                pij,
                                dynamicTable[pij].Distance + this.Estimator.NucleotideDistance(alignment.First[ii], alignment.Second[jj])
                            }
                        };

                    var d = estimates.Values.Min();
                    var dynamicTableItem = new DynamicTableItem(d, estimates.Where(e => e.Value.IsEqualTo(d)).Select(e => e.Key).ToList());
                    dynamicTable.Add(new Index(i, j), dynamicTableItem);
                }
            }

            return dynamicTable;
        }
    }
}
