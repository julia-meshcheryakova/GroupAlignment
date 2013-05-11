
namespace GroupAlignment.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Models.Group;

    /// <summary>
    /// Column - chain of the nucleotides
    /// </summary>
    public class Column : BaseColumn
    {
        /// <summary>
        /// Gets profile for column.
        /// </summary>
        /// <returns>The statistics dictionary.</returns>
        public ProfileItem ColumnProfile
        {
            get
            {
                var count = this.Count;
                if (count == 0)
                {
                    return new ProfileItem();
                }

                var nucleotideList = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToList();
                var columnProfile = Enum.GetValues(typeof(Nucleotide))
                                     .Cast<Nucleotide>()
                                     .ToDictionary(e => e, e => (double)nucleotideList.Count(n => n == e) / count);

                // return new ProfileItem(columnProfile.Where(p => p.Value > 0));
                return new ProfileItem(columnProfile);
            }
        }
    }
}