﻿
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    using GroupAlignment.Core.Models.Pair;

    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// Alignment - list of the sequences
    /// </summary>
    public class PairAlignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairAlignment"/> class.
        /// </summary>
        public PairAlignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PairAlignment"/> class.
        /// </summary>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        public PairAlignment(Sequence sequence1, Sequence sequence2)
        {
            this.First = sequence1;
            this.Second = sequence2;
            this.Ways = new List<List<Index>>();
            this.AlignedSequences = new List<PairSequence>();
            this.DynamicTable = new DynamicTable();
        }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public Sequence First { get; set; }

        /// <summary>
        /// Gets or sets first original sequence.
        /// </summary>
        public Sequence Second { get; set; }

        /// <summary>
        /// Gets or sets the distance dynamic table.
        /// </summary>
        public DynamicTable DynamicTable { get; set; }

        /// <summary>
        /// Gets or sets ways of alignment if dynamic table.
        /// </summary>
        public List<List<Index>> Ways { get; set; }

        /// <summary>
        /// Gets or sets variants of sequences alignments.
        /// </summary>
        public List<PairSequence> AlignedSequences { get; set; }

        /// <summary>
        /// Gets the distance.
        /// </summary>
        public double Distance
        {
            get
            {
                return this.DynamicTable[new Index(this.First.Count, this.Second.Count)].Distance;
            }
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length
        {
            get
            {
                return this.First.Count;
            }
        }
    }
}