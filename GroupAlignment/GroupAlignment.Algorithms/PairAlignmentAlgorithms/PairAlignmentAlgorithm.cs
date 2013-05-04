
namespace GroupAlignment.Algorithms.PairAlignmentAlgorithms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using GroupAlignment.Algorithms.Estimators;
    using GroupAlignment.Core.Models;

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
            if (alignment.DynamicTable.Count == 0)
            {
                this.FillDynamic(alignment);
            }

            // fill variants
            var length = alignment.Length;
            var variants = new List<List<Pair>>();
            variants.Add(new List<Pair> { new Pair(length, length) });
            while (variants.Any(l => (l.First().First as int?) != 0 && (l.First().Second as int?) != 0))
            {
                foreach (var variant in variants.Where(l => (l.First().First as int?) != 0 && (l.First().Second as int?) != 0))
                {
                    var pair = variant.First();
                    var predecessors = alignment.DynamicTable[pair].Predecessors;
                    var newVariants = new List<List<Pair>> { variant };
                    for (var i = 1; i < predecessors.Count; ++i)
                    {
                        newVariants.Add(new List<Pair>(variant));
                    }

                    for (var i = 0; i < predecessors.Count; ++i)
                    {
                        newVariants[i].Insert(0, predecessors[i]);
                    }

                    variants.Remove(variant);
                    variants.AddRange(newVariants);
                }
            }

            var sequences = new List<PairSequence>();
            foreach (var variant in variants)
            {
                var sequence = new PairSequence();
                for (var i = 1; i < variant.Count; ++i)
                {
                    var pred = variant[i - 1];
                    var cur = variant[i];
                    if (pred.First.Equals(cur.First))
                    {
                        sequence.Add(new NucleotidePair(Nucleotide._, alignment.Second[(int)cur.Second]));
                    }
                    else if (pred.Second.Equals(cur.Second))
                    {
                        sequence.Add(new NucleotidePair(alignment.First[(int)cur.First], Nucleotide._));
                    }
                    else
                    {
                        sequence.Add(new NucleotidePair(alignment.First[(int)cur.First], alignment.Second[(int)cur.Second]));
                    }
                }

                sequences.Add(sequence);
            }

            return sequences;
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The aligned sequence variants.</returns>
        public void FillGraphWays(PairAlignment alignment)
        {
            alignment.Ways = this.GenerateGraphWays(alignment);
        }

        /// <summary>
        /// The generate aligned.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The aligned sequence variants.</returns>
        public List<List<Pair>> GenerateGraphWays(PairAlignment alignment)
        {
            if (alignment.DynamicTable.Count == 0)
            {
                this.FillDynamic(alignment);
            }

            // fill variants
            var length = alignment.Length;
            var ways = new List<List<Pair>>();
            ways.Add(new List<Pair> { new Pair(length, length) });
            while (ways.Any(l => (l.First().First as int?) != 0 && (l.First().Second as int?) != 0))
            {
                foreach (var way in ways.Where(l => (l.First().First as int?) != 0 && (l.First().Second as int?) != 0))
                {
                    var pair = way.First();
                    var predecessors = alignment.DynamicTable[pair].Predecessors;
                    var newWays = new List<List<Pair>> { way };
                    for (var i = 1; i < predecessors.Count; ++i)
                    {
                        newWays.Add(new List<Pair>(way));
                    }

                    for (var i = 0; i < predecessors.Count; ++i)
                    {
                        newWays[i].Insert(0, predecessors[i]);
                    }

                    ways.Remove(way);
                    ways.AddRange(newWays);
                }
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
        private Dictionary<Pair, DynamicTableItem> GenerateDynamicTable(PairAlignment alignment)
        {
            var length = alignment.Length + 1;
            var dynamicTable = new Dictionary<Pair, DynamicTableItem>
                {
                    { new Pair(0, 0), new DynamicTableItem(0, new List<Pair>()) }
                };

            // first row and column set
            for (var i = 1; i < length; i++)
            {
                dynamicTable.Add(new Pair(0, i), new DynamicTableItem(i * this.Estimator.NucleotideDistance(alignment.Second[i], Nucleotide._), new List<Pair> { new Pair(0, i - 1) }));
                dynamicTable.Add(new Pair(i, 0), new DynamicTableItem(i * this.Estimator.NucleotideDistance(alignment.First[i], Nucleotide._), new List<Pair> { new Pair(i - 1, 0) }));
            }

            for (var i = 1; i < length; i++)
            {
                for (var j = 1; j < length; j++)
                {
                    var pj = new Pair(i - 1, j); // same column
                    var pi = new Pair(i, j - 1); // same row
                    var pij = new Pair(i - 1, j - 1);
                    var estimates = new Dictionary<Pair, int>
                        {
                            { pj, dynamicTable[pj].Distance + this.Estimator.NucleotideDistance(alignment.First[i], Nucleotide._) },
                            { pi, dynamicTable[pi].Distance + this.Estimator.NucleotideDistance(Nucleotide._, alignment.Second[j]) },
                            {
                                pij,
                                dynamicTable[pij].Distance + this.Estimator.NucleotideDistance(alignment.First[i], alignment.Second[j])
                            }
                        };

                    var d = estimates.Values.Max();
                    var dynamicTableItem = new DynamicTableItem(d, estimates.Where(e => e.Value == d).Select(e => e.Key).ToList());
                    dynamicTable.Add(new Pair(i, j), dynamicTableItem);
                }
            }

            return dynamicTable;
        }
    }
}
