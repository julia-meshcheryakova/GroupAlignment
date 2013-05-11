namespace GroupAlignment.Core.Tests.PairAlignmentAlgorithmsTests
{
    using System;

    using GroupAlignment.Core.Algorithms;
    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultipleAlignmentAlgorithmTests
    {
        [TestMethod]
        public void FillAlignedSequencesWithDifferentCountTest()
        {
            // AACGCTAG
            // ATCCTAG
            var sequence1 = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide.G,
                    Nucleotide.C,
                    Nucleotide.T,
                    Nucleotide.A,
                    Nucleotide.G
                };
            var sequence2 = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.T,
                    Nucleotide.C,
                    Nucleotide.C,
                    Nucleotide.T,
                    Nucleotide.A,
                    Nucleotide.G
                };
            var multipleAlignment1 = new MultipleAlignment(new[] { sequence1 });
            var multipleAlignment2 = new MultipleAlignment(new[] { sequence2 });
            var asdf = multipleAlignment1.Profiles;
            var newMultipleAlignment = new MultipleAlignment(multipleAlignment1, multipleAlignment2);
            var algorithm = new MultipleAlignmentAlgorithm(new OperationDistanceEstimator(4, 2, 0, 1));
            algorithm.FillAlignedSequences(newMultipleAlignment);
        }
    }
}
