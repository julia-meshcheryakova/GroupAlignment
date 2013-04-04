
namespace GroupAlignment.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Column - chain of the nucleotides
    /// </summary>
    public class Column : BaseColumn
    {
        /// <summary>
        /// Gets statistics for column.
        /// </summary>
        /// <returns>The statistics dictionary.</returns>
        public Dictionary<Nucleotide, double> Statistics()
        {
            var count = this.Count;
            if (count == 0)
            {
                return new Dictionary<Nucleotide, double>();
            }

            var nucleotideList = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToList();
            var statistics = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToDictionary(e => e, e => (double)nucleotideList.Count(n => n == e) / count);
            return statistics;
        }
    }
}