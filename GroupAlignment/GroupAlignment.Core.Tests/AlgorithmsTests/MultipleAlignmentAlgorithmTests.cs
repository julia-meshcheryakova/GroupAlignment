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
            var sequence1 =
                new Sequence(
                    new[]
                        {
                            Nucleotide.A, Nucleotide.A, Nucleotide.C, Nucleotide.G, Nucleotide.C, Nucleotide.T,
                            Nucleotide.A, Nucleotide.G
                        },
                    1);
            var sequence2 =
                new Sequence(
                    new[]
                        {
                            Nucleotide.A, Nucleotide.T, Nucleotide.C, Nucleotide.C, Nucleotide.T, Nucleotide.A,
                            Nucleotide.G
                        },
                    2);

            var estimator = new OperationDistanceEstimator(4, 2, 0, 1);
            var multipleAlignment1 = new MultipleAlignment(1, new[] { sequence1 }, estimator);
            var multipleAlignment2 = new MultipleAlignment(2, new[] { sequence2 }, estimator);
            var newMultipleAlignment = new MultipleAlignment(3, multipleAlignment1, multipleAlignment2);
            var algorithm = new MultipleAlignmentAlgorithm(estimator);
            var groupAlgorithm = new GroupAlignmentAlgorithm(estimator);
            algorithm.FillAlignedSequences(newMultipleAlignment, groupAlgorithm.GeneratePairAlignmentsMap(newMultipleAlignment));
        }
    }
}
