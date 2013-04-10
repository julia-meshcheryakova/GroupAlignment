
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
        public PairAlignmentAlgorithm(OperationDistanceEstimator estimator)
        {
            this.Estimator = estimator;
        }

        /// <summary>
        /// Gets or sets the estimator.
        /// </summary>
        public OperationDistanceEstimator Estimator { get; set; }

        /// <summary>
        /// The generate method.
        /// </summary>
        /// <param name="alignment">The pair alignment.</param>
        public void Generate(PairAlignment alignment)
        {
            alignment.DynamicTable = this.DynamicTableFill(alignment);
        }

        /// <summary>
        /// The dynamic table fill.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The <see cref="Dictionary"/> dynamic table.</returns>
        private Dictionary<Pair, DynamicTableItem> DynamicTableFill(PairAlignment alignment)
        {
            var length = alignment.Length + 1;
            var dynamicTable = new Dictionary<Pair, DynamicTableItem>
                {
                    { new Pair(0, 0), new DynamicTableItem(0, new List<Pair>()) }
                };

            // first row and column set
            for (var i = 1; i < length; i++)
            {
                dynamicTable.Add(new Pair(0, i), new DynamicTableItem(i, new List<Pair> { new Pair(0, i - 1) }));
                dynamicTable.Add(new Pair(i, 0), new DynamicTableItem(i, new List<Pair> { new Pair(i - 1, 0) }));
            }

            for (var i = 1; i < length; i++)
            {
                for (var j = 1; j < length; j++)
                {
                    var pi = new Pair(i - 1, j);
                    var pj = new Pair(i, j - 1);
                    var pij = new Pair(i - 1, j - 1);
                    var estimates = new Dictionary<Pair, int>
                        {
                            { pi, dynamicTable[pi].Distance + this.Estimator.Delete },
                            { pj, dynamicTable[pj].Distance + this.Estimator.Delete },
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
