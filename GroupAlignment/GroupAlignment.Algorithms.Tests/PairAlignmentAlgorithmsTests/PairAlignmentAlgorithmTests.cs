namespace GroupAlignment.Algorithms.Tests.PairAlignmentAlgorithmsTests
{
    using System;

    using GroupAlignment.Algorithms.Estimators;
    using GroupAlignment.Algorithms.PairAlignmentAlgorithms;
    using GroupAlignment.Core.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PairAlignmentAlgorithmTests
    {
        [TestMethod]
        public void FillAlignedSequencesTest()
        {
            // AACGCTN
            // ATCCTNG
            var sequence1 = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide.G,
                    Nucleotide.C,
                    Nucleotide.T,
                    Nucleotide.N
                };
            var sequence2 = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.T,
                    Nucleotide.C,
                    Nucleotide.C,
                    Nucleotide.T,
                    Nucleotide.N,
                    Nucleotide.G
                };
            var pairAlignment = new PairAlignment(sequence1, sequence2);
            var algorithm = new PairAlignmentAlgorithm(new OperationDistanceEstimator(4, 2, 0, 1));
            algorithm.FillAlignedSequences(pairAlignment);
        }
    }
}
