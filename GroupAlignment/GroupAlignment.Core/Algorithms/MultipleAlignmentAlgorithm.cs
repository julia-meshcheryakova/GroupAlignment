
namespace GroupAlignment.Core.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Extensions;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;
    using GroupAlignment.Core.Models.Pair;

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
        /// The dynamic table fill.
        /// </summary>
        /// <param name="first">The first sequence.</param>
        /// <param name="second">The second sequence.</param>
        /// <returns>The dynamic table.</returns>
        private Dictionary<Index, DynamicTableItem> GenerateProfilesTable(Profile first, Profile second)
        {
            var length1 = first.Count + 1;
            var length2 = second.Count + 1;
            var dynamicTable = new Dictionary<Index, DynamicTableItem>
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
