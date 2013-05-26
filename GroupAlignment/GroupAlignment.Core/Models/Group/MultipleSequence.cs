
namespace GroupAlignment.Core.Models.Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Sequence - chain of the nucleotides
    /// </summary>
    public class MultipleSequence : List<Column>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSequence"/> class.
        /// </summary>
        public MultipleSequence()
        {
            this.Sequences = new List<Sequence>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSequence"/> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        public MultipleSequence(Sequence sequence)
            : this()
        {
            foreach (var n in sequence)
            {
                this.Add(new Column(new List<Nucleotide> { n }));
            }
            this.Sequences.Add(sequence);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSequence"/> class.
        /// </summary>
        /// <param name="sequences">The sequence.</param>
        public MultipleSequence(IEnumerable<Sequence> sequences)
            : this()
        {
            var list = sequences.ToList();
            this.Sequences.AddRange(list);
            var maxLength = list.Max(s => s.Count);
            var completedSequences = list.Select(s => Sequence.Complete(s, maxLength)).ToList();
            for (var i = 0; i < maxLength; i++)
            {
                this.Add(new Column(completedSequences.Select(s => s[i])));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSequence"/> class.
        /// </summary>
        /// <param name="list">The list of nucleotide pairs.</param>
        public MultipleSequence(IEnumerable<Column> list)
            : this()
        {
            this.AddRange(list);
        }

        public List<Sequence> Sequences { get; set; }

        /// <summary>
        /// Gets the profile (enumerated from 1).
        /// </summary>
        public Profile Profile
        {
            get
            {
                var profile = new Profile();
                for (var i = 0; i < this.Count; i++)
                {
                    var column = this[i];
                    profile.Add(column.ColumnProfile);
                }

                // TODO: check if that is the same
                var profile2 = this.Select(column => column.ColumnProfile).ToList();
                var useLinq = profile.SequenceEqual(profile2);

                return profile;
            }
        }

        public List<Sequence> ToSequenceList()
        {
            var list = new List<Sequence>();
            for (var i = 0; i < this.First().Count; i++)
            {
                list.Add(new Sequence(this.Select(column => column[i]).ToList()));
            }
            return list;
        }

        /// <summary>
        /// Cast to string.
        /// </summary>
        /// <returns>The sequence string.</returns>
        public new string ToString()
        {
            var sb = new StringBuilder();
            foreach (var sequence in this.Sequences)
            {
                sb.AppendFormat("{0} \t{1}", sequence.Id.Value, sequence.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}