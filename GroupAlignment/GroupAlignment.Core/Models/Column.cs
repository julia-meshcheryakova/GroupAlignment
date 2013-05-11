
namespace GroupAlignment.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GroupAlignment.Core.Models.Group;

    /// <summary>
    /// Column - chain of the nucleotides
    /// </summary>
    public class Column : List<Nucleotide>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class.
        /// </summary>
        public Column()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class as merge of two columns.
        /// </summary>
        /// <param name="column">The nucleotide list.</param>
        public Column(IEnumerable<Nucleotide> column)
        {
            this.AddRange(column);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class as merge of two columns.
        /// </summary>
        /// <param name="column1">The column 1.</param>
        /// <param name="column2">The column 2.</param>
        public Column(IEnumerable<Nucleotide> column1, IEnumerable<Nucleotide> column2)
        {
            this.AddRange(column1);
            this.AddRange(column2);
        }

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
                var columnProfile = nucleotideList
                                     .ToDictionary(e => e, e => (double)this.Count(n => n == e) / count);

                // return new ProfileItem(columnProfile.Where(p => p.Value > 0));
                return new ProfileItem(columnProfile);
            }
        }

        /// <summary>
        /// The get clear column with definite count of spaces.
        /// </summary>
        /// <param name="count">The count of .</param>
        /// <returns>The <see cref="Column"/>.</returns>
        public static Column GetClearColumn(int count)
        {
            var column = new Column();
            for (var j = 0; j < count; j++)
            {
                column.Add(Nucleotide._);
            }

            return column;
        }
    }
}