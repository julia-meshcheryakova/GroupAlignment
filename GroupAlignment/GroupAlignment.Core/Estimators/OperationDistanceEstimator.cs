﻿
namespace GroupAlignment.Core.Estimators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using GroupAlignment.Core.Extensions;
    using GroupAlignment.Core.Models;

    /// <summary>
    /// Distance estimator class based on the operation-weight
    /// </summary>
    public class OperationDistanceEstimator : AbstractDistanceEstimator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationDistanceEstimator"/> class.
        /// </summary>
        /// <param name="delete">The delete weight.</param>
        /// <param name="replace">The replace weight.</param>
        /// <param name="equality">The equality weight.</param>
        /// <param name="undefined">The undefined weight.</param>
        public OperationDistanceEstimator(double delete, double replace, double equality, double undefined)
        {
            this.Delete = delete;
            this.Replace = replace;
            this.Equality = equality;
            this.Undefined = undefined;
            this.DistanceMap = new Dictionary<NucleotidePair, double>();
            var allNucleotides = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToList();
            var allPairs = (from first in allNucleotides 
                            from second in allNucleotides 
                            select new NucleotidePair(first, second)).ToList();
            var pairsNotEqual = allPairs.Where(p => p.First != p.Second).ToList();
            var pairsEqual = allPairs
                .Where(p => p.First == p.Second && p.First != Nucleotide.N)
                .ToDictionary(p => p, p => this.Equality);
            var pairsSpace = pairsNotEqual
                .Where(p => p.First == Nucleotide._ || p.Second == Nucleotide._)
                .ToDictionary(p => p, p => this.Delete);
            var pairsN = pairsNotEqual
                .Where(p => (p.First == Nucleotide.N || p.Second == Nucleotide.N) && (p.First != Nucleotide._ && p.Second != Nucleotide._))
                .ToDictionary(p => p, p => this.Undefined);
            var pairsReplace =
                pairsNotEqual
                .Where(p => p.First != Nucleotide.N && p.Second != Nucleotide.N 
                         && p.First != Nucleotide._ && p.Second != Nucleotide._)
                .ToDictionary(p => p, p => this.Replace);
            this.DistanceMap.AddRange(pairsReplace);
            this.DistanceMap.AddRange(pairsSpace);
            this.DistanceMap.AddRange(pairsN);
            this.DistanceMap.AddRange(pairsEqual);
            this.DistanceMap.Add(new NucleotidePair(Nucleotide.N, Nucleotide.N), this.Undefined);
        }

        /// <summary>
        /// Gets or sets the distance delete - distance with _.
        /// </summary>
        public double Delete { get; set; }

        /// <summary>
        /// Gets or sets the replace weight - distance with the other nucleotide.
        /// </summary>
        public double Replace { get; set; }

        /// <summary>
        /// Gets or sets the equal weight - nucleotides match.
        /// </summary>
        public double Equality { get; set; }

        /// <summary>
        /// Gets or sets the N weight - with undefined nucleotide.
        /// </summary>
        public double Undefined { get; set; }

        /// <summary>
        /// Gets the distance map.
        /// </summary>
        public Dictionary<NucleotidePair, double> DistanceMap { get; private set; }
            
        /// <summary>
        /// Gets simple distance estimate for 2 sequences
        /// </summary>
        /// <param name="sequence1">The sequence 1.</param>
        /// <param name="sequence2">The sequence 2.</param>
        /// <returns>Distance estimate</returns>
        public override double Distance(Sequence sequence1, Sequence sequence2)
        {
            var maxLength = Math.Max(sequence1.Count, sequence2.Count);
            sequence1 = Sequence.Complete(sequence1, maxLength);
            sequence2 = Sequence.Complete(sequence2, maxLength);
            var pairSequence = Extensions.ToPair(sequence1, sequence2, (x, y) => new NucleotidePair(x, y));
            var res = pairSequence.Sum(pair => this.NucleotideDistance(pair.First, pair.Second));
            return res;
        }

        /// <summary>
        /// Gets simple distance estimate for 2 sequences
        /// </summary>
        /// <param name="pair">The sequence pair.</param>
        /// <returns>Distance estimate</returns>
        public override double Distance(PairAlignment pair)
        {
            return pair.DynamicTable[new Index(pair.First.Count, pair.Second.Count)].Distance;
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="n1">The nucleotide 1.</param>
        /// <param name="n2">The nucleotide 2.</param>
        /// <returns>Distance estimate</returns>
        public override double NucleotideDistance(Nucleotide n1, Nucleotide n2)
        {
            return this.DistanceMap[new NucleotidePair(n1, n2)];
        }

        /// <summary>
        /// Gets simple distance estimate for 2 nucleotides
        /// </summary>
        /// <param name="pair">The nucleotide pair.</param>
        /// <returns>Distance estimate</returns>
        public override double NucleotideDistance(NucleotidePair pair)
        {
            return this.DistanceMap[pair];
        }
    }
}
